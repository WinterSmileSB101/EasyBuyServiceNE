USE EasyBuy
GO

IF(EXISTS (SELECT * FROM sys.objects WHERE name = 'payForOrderSP'))
	DROP PROCEDURE payForOrderSP
GO

CREATE PROCEDURE payForOrderSP
	(@OrderID VARCHAR(20),
	@EditUser VARCHAR(200),
	@TransactionNumber VARCHAR(19),
	@Result INT OUTPUT)
AS
SET NOCOUNT ON
BEGIN
	DECLARE @PayCostomerID VARCHAR(200),
			@Money INT,
			@SellerID VARCHAR(200);
	BEGIN TRY
		BEGIN TRANSACTION
		IF(RTRIM(LTRIM(@OrderID)) IS NULL)
			BEGIN
				RAISERROR('OrderID Can not be NULL',16,1);
			END
		ELSE
			BEGIN
				IF(EXISTS (SELECT [PayCostomerID] FROM [dbo].[Order] WITH(NOLOCK) WHERE [OrderID]=@OrderID AND DATEDIFF(hh,[InDate],GETDATE()) < [NeedPayTime] AND [PayState]=0))
					BEGIN 
						SELECT @PayCostomerID=[PayCostomerID],@Money=[OrderTotal]*((100-[Discount])/100),@SellerID=[SellerID] FROM [dbo].[Order] WITH(NOLOCK) WHERE [OrderID]=@OrderID AND DATEDIFF(hh,[InDate],GETDATE()) < [NeedPayTime] AND [PayState]=0;
						IF(EXISTS (SELECT [UserID] FROM [dbo].[UserHighLevel] WITH(NOLOCK) WHERE [UserID]=@PayCostomerID AND [Balance]>=@Money))
							BEGIN
								SELECT N'足够';
								/*reduce money*/
								UPDATE [dbo].[UserHighLevel] SET [Balance]=[Balance]-@Money,[LastEditDate]=GETDATE(),[LastEditUser]=@EditUser WHERE [UserID]=@PayCostomerID AND [Balance]>=@Money;
								INSERT INTO [dbo].[TransactionHistory]
								([TransactionNumber]
								,[FromUser]
								,[ToUser]
								,[Title]
								,[State]
								,[Status]
								,[Description]
								,[Comment]
								,[Number]
								,[InDate]
								,[InUser]
								,[LastEditDate]
								,[LastEditUser])
									VALUES
										(@TransactionNumber+'0'
										,@PayCostomerID
										,@SellerID
										,N'购买商品'
										,1
										,0
										,N'购买商品'
										,N'成功'
										,@Money
										,GETDATE()
										,@EditUser
										,GETDATE()
										,@EditUser);
								/*add money*/
								UPDATE [dbo].[UserHighLevel] SET [Balance]=[Balance]+@Money,[LastEditDate]=GETDATE(),[LastEditUser]=@EditUser WHERE [UserID]=@PayCostomerID;
								INSERT INTO [dbo].[TransactionHistory]
								([TransactionNumber]
								,[FromUser]
								,[ToUser]
								,[Title]
								,[State]
								,[Status]
								,[Description]
								,[Comment]
								,[Number]
								,[InDate]
								,[InUser]
								,[LastEditDate]
								,[LastEditUser])
								VALUES
									(@TransactionNumber+'1'
									,@PayCostomerID
									,@SellerID
									,N'售卖商品'
									,1
									,1
									,N'售卖商品'
									,N'成功'
									,@Money
									,GETDATE()
									,@EditUser
									,GETDATE()
									,@EditUser);
								/*Update Order State*/
								UPDATE [dbo].[Order] SET [PayState]=1 WHERE [OrderID]=@OrderID AND [PayState]=0;
						END
						ELSE
							BEGIN
								RAISERROR('The User Is not exists OR User did not have enough money to pay this.',16,1);
							END
					END
				ELSE
					BEGIN
						RAISERROR('There is No Order need to be pay',16,1);
					END
				
			END
		COMMIT TRANSACTION
		SET @result=1;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		/*must after RollBack to avoid be rollback*/
		SET @Result = -1;
		/*SELECT ERROR_MESSAGE(),ERROR_NUMBER(),@InUser;*/
		INSERT INTO [EasyBuy].[dbo].[ErrorLog]
           ([Type]
           ,[RowNumber]
           ,[Description]
           ,[Level]
           ,[InDate]
           ,[InUser]
           ,[LastEditUser]
           ,[LastEditDate])
		 VALUES
			   (1
			   ,ERROR_NUMBER()
			   ,ERROR_MESSAGE()
			   ,1
			   ,GETDATE()
			   ,@EditUser
			   ,@EditUser
			   ,GETDATE());
	END CATCH
END
GO

DECLARE @Result INT

EXEC payForOrderSP '20180114','az8g','0000000002',@Result OUTPUT

SELECT @Result AS 结果
GO