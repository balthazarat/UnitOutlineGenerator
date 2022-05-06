BULK INSERT OutlineDataTBL -- The table we want to put the CSV in
FROM 'C:\Users\Administrator\Downloads\courseData.csv' -- Location of the CSV file
WITH
(
    FIRSTROW = 2, -- as 1st one is header
    FIELDTERMINATOR = '|',  --CSV field delimiter
    ROWTERMINATOR = '\n',   --Use to shift the control to next row
    TABLOCK
)