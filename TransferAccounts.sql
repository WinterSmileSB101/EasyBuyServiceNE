USE EasyBuy
GO

IF(EXISTS (SELECT * FROM sys.objects WHERE name = 'transferAccountsSP'))
	DROP PROCEDURE transferAccountsSP
GO

CREATE PROCEDURE transferAccountsSP
	(@FromUser VARCHAR(200),
	@ToUser VARCHAR(200),
	@TransferNumber INT,
	@TransactionNumber VARCHAR(19),
	@EditUser VARCHAR(200),
	@Result INT OUTPUT)
AS
SET NOCOUNT ON
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			IF(EXISTS (SELECT [UserID] FROM [dbo].[UserHighLevel] WITH(NOLOCK) WHERE [UserID]=@ToUser))
				BEGIN
					IF(EXISTS (SELECT [UserID] FROM [dbo].[UserHighLevel] WITH(NOLOCK) WHERE [UserID]=@FromUser AND [Balance]>=@TransferNumber))
						BEGIN
							/*reduce money*/
								UPDATE [dbo].[UserHighLevel] SET [Balance]=[Balance]-@TransferNumber,[LastEditDate]=GETDATE(),[LastEditUser]=@EditUser WHERE [UserID]=@FromUser AND [Balance]>=@TransferNumber;
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
										,@FromUser
										,@ToUser
										,N'转出给 '+@ToUser
										,1
										,0
										,N'转出给 '+@ToUser
										,N'成功'
										,@TransferNumber
										,GETDATE()
										,@EditUser
										,GETDATE()
										,@EditUser);
								/*add money*/
								UPDATE [dbo].[UserHighLevel] SET [Balance]=[Balance]+@TransferNumber,[LastEditDate]=GETDATE(),[LastEditUser]=@EditUser WHERE [UserID]=@ToUser;
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
									,@FromUser
									,@ToUser
									,N'收到 '+@FromUser+' 的转账'
									,1
									,1
									,N'收到 '+@FromUser+' 的转账'
									,N'成功'
									,@TransferNumber
									,GETDATE()
									,@EditUser
									,GETDATE()
									,@EditUser);
						END
					ELSE
						BEGIN
							RAISERROR('User did not have enough money.',16,1);
						END
				END
			ELSE
				BEGIN
					RAISERROR('There is no catch people.',16,1);
				END
		COMMIT TRANSACTION
		SET @Result=1;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		/*must after RollBack to avoid be rollback*/
		SET @Result = -1;
		/*add filed item to transhistory table*/
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
						,@FromUser
						,@ToUser
						,N'转出给 '+@ToUser
						,0
						,0
						,N'转出给 '+@ToUser
						,N'失败'
						,@TransferNumber
						,GETDATE()
						,@EditUser
						,GETDATE()
						,@EditUser);
		/*SELECT ERROR_MESSAGE(),ERROR_NUMBER(),@InUser;*/
		INSERT INTO [EasyBuy].[dbo].[ErrorLog]
           ([Type]
           ,[RowNumber]
			,[TransactionNumber]
           ,[Description]
           ,[Level]
           ,[InDate]
           ,[InUser]
           ,[LastEditUser]
           ,[LastEditDate])
		 VALUES
			   (1
			   ,ERROR_NUMBER()
				,@TransactionNumber+'0'
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

EXEC transferAccountsSP '20180114','20180115',100,'1564545455','az8g',@Result OUTPUT

SELECT @Result AS 结果
GO