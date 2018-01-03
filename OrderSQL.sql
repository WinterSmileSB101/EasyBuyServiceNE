USE EasyBuy
GO

IF(EXISTS (SELECT * FROM sys.objects WHERE name = 'addOrderSP'))
	DROP PROCEDURE addOrderSP
GO

CREATE PROCEDURE addOrderSP
	(@OrderID VARCHAR(20),
	@OrderState INT,
	@CostomerID VARCHAR(200),
	@OrderTotal INT,
	@AddressID INT,
	@PayState BIT,
	@Discount INT,
	@PayCostomerID VARCHAR(200),
	@Comment NVARCHAR(MAX),
	@NeedPayTime INT,
	@InUser VARCHAR(200),
	@DetailInfo VARCHAR(MAX),
	@Result INT OUTPUT)
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @SingleDetail VARCHAR(200),
			@ProductID VARCHAR(20),
			@PostID VARCHAR(50),
			@NeedCount INT,
			@RemainCount INT,
			@ExecuteTime VARCHAR(50);
	BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO [dbo].[Order]
		([OrderID],
		[OrderState],
		[CostomerID],
		[OrderTotal],
		[AddressID],
		[PayState],
		[Discount],
		[PayCostomerID],
		[Comment],
		[NeedPayTime],
		[InUser],
		[LastEditUser],
		[InDate],
		[LastEditDate])
		VALUES
		(@OrderID,
		@OrderState,
		@CostomerID,
		@OrderTotal,
		@AddressID,
		@PayState,
		@Discount,
		@PayCostomerID,
		@Comment,
		@NeedPayTime,
		@InUser,
		@InUser,
		GETDATE(),
		GETDATE());
		SELECT @DetailInfo,CHARINDEX(';',@DetailInfo);
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
						SELECT @ProductID,@NeedCount,@PostID;
						SELECT @RemainCount=[Stock] FROM [dbo].[Product] WITH(NOLOCK) WHERE [ProductID]=@ProductID AND [IsPublish]=1;
						IF(@RemainCount >= @NeedCount)
							BEGIN
								UPDATE [dbo].[Product] SET [Stock]=[Stock]-@NeedCount WHERE [ProductID]=@ProductID AND [IsPublish]=1;
								INSERT INTO [dbo].[OrderDetail]
								([OrderID],
								[ProductID],
								[PostID],
								[InUser],
								[LastEditUser],
								[InDate],
								[LastEditDate])
								VALUES
								(@OrderID,
								@ProductID,
								@PostID,
								@InUser,
								@InUser,
								GETDATE(),
								GETDATE());
								/*wait some time to execute restore sp*/
								SET @ExecuteTime = CONVERT(VARCHAR,DATEADD(hh,@NeedPayTime,GETDATE()),120);
								WAITFOR TIME @ExecuteTime
								EXECUTE updateProductStock @OrderID,@DetailInfo,@Result OUTPUT;
							END
						ELSE
							BEGIN
								RAISERROR('Stock<OrderCount',16,1); 
							END
					END
				
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
				,''
			   ,ERROR_MESSAGE()
			   ,1
			   ,GETDATE()
			   ,@InUser
			   ,@InUser
			   ,GETDATE());
	END CATCH
		
END
GO

DECLARE @Result INT

EXEC addOrderSP '201801224',0,'0000000001',100,1,0,10,'0000000002','','az8g','002235256451,2,1;',@Result OUTPUT

SELECT @Result AS ½á¹û