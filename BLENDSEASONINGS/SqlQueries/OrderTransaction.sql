Drop Table [OrderTransaction]

Select * From [OrderTransaction]

Create Table [OrderTransaction](
	id int not null identity primary key,
	blendId int not null,
	orderId int not null 
);

Insert into [OrderTransaction](blendId, orderId)
Values (1,1)

Insert into [OrderTransaction](blendId, orderId)
Values (2,2)

Insert into [OrderTransaction](blendId, orderId)
Values (3,3)