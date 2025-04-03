--SELECT 'new Image { Id = ' + CAST(Id AS VARCHAR) + ', Path = "' + Path + '" },'
--FROM Images;


--SELECT 'new Category { Id = ' + CAST(Id AS VARCHAR) 
--       + ', Name = "' + Name + '"'
--       + ', Description = "' + Description + '"'
--       + ', ImageId = ' + CAST(ImageId AS VARCHAR) + ' },'
--FROM Categories;

--SELECT 
--    'new Comment { Id = ' + CAST(Id AS VARCHAR) + 
--    ', Text = "' + REPLACE(Text, '"', '""') + '"' + 
--    ', ProjectId = ' + CAST(ProjectId AS VARCHAR) + 
--    ', UserId = ' + CAST(UserId AS VARCHAR) + 
--    CASE WHEN ImageId IS NOT NULL THEN ', ImageId = ' + CAST(ImageId AS VARCHAR) ELSE '' END + 
--    ', DateAdded = DateTime.Parse("' + FORMAT(DateAdded, 'yyyy-MM-dd HH:mm:ss') + '") },'
--FROM Comments;

--SELECT 
--    'new Project { Id = ' + CAST(Id AS VARCHAR) + 
--    ', Title = ^^^' + REPLACE(Title, '"', '\"') + '^^^' + 
--    ', ShortDescription = ^^^' + REPLACE(ShortDescription, '"', '\"') + '^^^' + 
--    ', Description = ^^^' + REPLACE(Description, '"', '\"') + '^^^' + 
--    ', CategoryId = ' + CAST(CategoryId AS VARCHAR) + 
--    ', UserId = ' + CAST(UserId AS VARCHAR) + 
--    ', ImageId = ' + CAST(ImageId AS VARCHAR) + 
--    ' },'
--FROM Projects;
-- -- to replace all ^^^ with " in the code 

--SELECT 
--    'new User { Id = ' + CAST(Id AS VARCHAR) + 
--    ', UserName = """' + UserName + '"""' + 
--    ', Email = """' + Email + '"""' + 
--    ', ProfilePictureId = ' + COALESCE(CAST(ProfilePictureId AS VARCHAR), 'NULL') + 
--    ', DateCreated = DateTime.Parse("""' + FORMAT(DateCreated, 'yyyy-MM-ddTHH:mm:ssZ') + '""")' +
--    ', DateUpdated = DateTime.Parse("""' + FORMAT(DateUpdated, 'yyyy-MM-ddTHH:mm:ssZ') + '""")' +
--    ' },'
--FROM AspNetUsers;

--SELECT 
--    'new LikedProjects { Id = ' + CAST(Id AS VARCHAR) + 
--    ', UserId = ' + CAST(UserId AS VARCHAR) + 
--    ', ProjectId = ' + CAST(ProjectId AS VARCHAR) + 
--    ' },'
--FROM LikedProjects;

SELECT 
    'new LikedComments { Id = ' + CAST(Id AS VARCHAR) + 
    ', UserId = ' + CAST(UserId AS VARCHAR) + 
    ', CommentId = ' + CAST(CommentId AS VARCHAR) + 
    ' },'
FROM LikedComments;




