Create table [Ingredient](
id int not null identity primary key,
blendId varchar (200),
spiceId varchar (200),
)

Select * From [Ingredient]

Select * From [Spice]


-- Delete Table 
Drop Table [Ingredients]

-- Fish Seasoning
INSERT INTO [Ingredient](blendId, spiceId)
Values ('1','1')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('1','2')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('1','18')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('1','3')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('1','5')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('1','8')

-- Italian Seasoning
INSERT INTO [Ingredient](blendId, spiceId)
Values ('2','10')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('2','16')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('2','9')

-- Asian Blend

INSERT INTO [Ingredient](blendId, spiceId)
Values ('3','13')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('3','3')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('3','2')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('3','5')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('3','11')

INSERT INTO [Ingredient](blendId, spiceId)
Values ('3','6')