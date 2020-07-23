SELECT 'ALTER SCHEMA TC TRANSFER [' + SysSchemas.Name + '].[' + DbObjects.Name + '];'
FROM sys.Objects DbObjects
INNER JOIN sys.Schemas SysSchemas ON DbObjects.schema_id = SysSchemas.schema_id
WHERE SysSchemas.Name = 'dbo'
AND (DbObjects.Type IN ('U', 'P', 'V'))




ALTER SCHEMA TC TRANSFER [dbo].[spTCSpeedDetails];
ALTER SCHEMA TC TRANSFER [dbo].[spTCSpeedSummaryBySite];
ALTER SCHEMA TC TRANSFER [dbo].[spTCSummaryByLoc];
ALTER SCHEMA TC TRANSFER [dbo].[spTCSummaryBySite];
ALTER SCHEMA TC TRANSFER [dbo].[spTCSummaryOneBySite];
ALTER SCHEMA TC TRANSFER [dbo].[spUpdateTCSummaryLocation];
ALTER SCHEMA TC TRANSFER [dbo].[spFindRoad1];
ALTER SCHEMA TC TRANSFER [dbo].[spFindRoad2];
ALTER SCHEMA TC TRANSFER [dbo].[spFindSite];
ALTER SCHEMA TC TRANSFER [dbo].[spFindTWPLegal];