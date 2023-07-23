USE [Book]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[sp_Validate]
		@UserName = N'fgad',
		@Password = N'dfgb'

SELECT	@return_value as 'Return Value'

GO
