USE [Book]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[sp_Validate]
		@UserName = N'Mukund',
		@Password = N'M@123'

SELECT	@return_value as 'Return Value'

GO
