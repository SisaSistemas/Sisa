SELECT  o.name, 
        o.type_desc,
        m.definition
FROM sys.objects o
JOIN sys.sql_modules m ON o.object_id = m.object_id
WHERE m.definition LIKE '%17.5%';