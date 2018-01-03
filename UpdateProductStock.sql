USE EasyBuy
GO

IF(EXISTS (SELECT * FROM sys.objects WHERE name = 'updateProductStock'))
	DROP PROCEDURE updateProductStock
GO

CREATE PROCEDURE updateProductStock
	(@OrderID VARCHAR(20),
	@DetailInfo VARCHAR(MAX),
	@Result INT OUTPUT)
AS 
SET NOCOUNT ON;
BEGIN
DECLARE @NeedCount INT;
	BEGIN TRY
		BEGIN TRANSACTION
			IF(EXISTS (SELECT [PayCostomerID] FROM [dbo].[Order] WITH(NOLOCK) WHERE [OrderID]=@OrderID AND DATEDIFF(hh,[InDate],GETDATE()) < [NeedPayTime] AND [PayState]=0))
				BEGIN
				IF(NOT EXISTS (SELECT [OrderID] FROM [dbo].[Order] WHERE [PayState]=1 AND [OrderID]=@OrderID))
					BEGIN
						WHILE(CHARINDEX(';',@DetailInfo)<>0)
						BEGIN
							SET @SingleDetail = SUBSTRING(@DetailInfo,1,CHARINDEX(';',@DetailInfo)-1);
							SET @DetailInfo = STUFF(@DetailInfo,1,CHARINDEX(';',@DetailInfo),'');
							SELECT @DetailInfo,@SingleDetail,@DetailInfo;
							IF(CHARINDEX(',',@SingleDetail)<>0)
								BEGIN
									SET @ProductID = SUBSTRING(@SingleDetail,1,CHARINDEX(',',@SingleDetail)-1);
									SET @SingleDetail = STUFF(@SingleDetail,1,CHARINDEX(',',@SingleDetail),'');
									SET @NeedCount = CONVERT(INT,SUBSTRING(@SingleDetail,1,CHARINDEX(',',@SingleDetail)-1));
									SET @PostID = STUFF(@SingleDetail,1,CHARINDEX(',',@SingleDetail),'');
									/*SELECT @ProductID,@NeedCount,@PostID;*/
									UPDATE [dbo].[Product] SET [Stock]=[Stock]+@NeedCount WHERE [ProductID]=@ProductID AND [IsPublish]=1;
								END
						END
					END
				END
			ELSE
				BEGIN
					RAISERROR('This Order is not meet the deadline.',16,1);
				END
		COMMIT TRANSACTION
		SET @Result = 1;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		/*must after RollBack to avoid be rollback*/
		SET @Result = -1;
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
				,@TransactionNumber
			   ,ERROR_MESSAGE()
			   ,1
			   ,GETDATE()
			   ,@EditUser
			   ,@EditUser
			   ,GETDATE());
	END CATCH
END
GO