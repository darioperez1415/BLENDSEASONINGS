--Create table for OrderTransaction 

Create Table [OrderTransaction](
	id int not null identity primary key,
	blendId varchar (255),
	orderId varchar (225), 
);

-- Look up OrderTransaction

Select * from [OrderTransaction]

-- Remove table from database incase need to start over

Drop Table [OrderTransaction]

Insert into [OrderTransaction](blendId, orderId)
Values ('1','1')

Insert into [OrderTransaction](blendId, orderId)
Values ('2','2')

Insert into [OrderTransaction](blendId, orderId)
Values ('3','3')
