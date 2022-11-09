DROP Table Blend

SELECT * FROM Blend
--Create new Table for Blend

Create Table [Blend](
  id int not null identity primary key, 
  name varchar (250),
  ingredients varchar (250),
  [price] decimal,
  imageUrl varchar(250)
)

-- Blend Insert statements

Insert into [Blend](name, ingredients, price, imageUrl)
Values ('Seafood Seasoning', 'Smoked Paprika or Sweet Paprika, Garlic Powder, Onion Powder,Thyme,Celery Seed,Cumin,Allspice,Salt',10,'https://www.acouplecooks.com/wp-content/uploads/2020/04/Seafood-Seasoning-007.jpg')

Insert into [Blend](name, ingredients, price, imageUrl)
Values ('Taco Seasoning', 'Chili powder,Ground Cumin,Paprika,Garlic Powder,Onion powder,Dried oregano,Salt and Black pepper',10,'https://www.acouplecooks.com/wp-content/uploads/2018/07/Taco-Seasoning-003.jpg')

Insert into [Blend](name, ingredients, price, imageUrl)
Values ('Greek Seasoning', 'Dried Oregano,Dried Dill,Garlic Powder,Onion Powder,Salt and Black Pepper',10,'https://www.acouplecooks.com/wp-content/uploads/2020/04/Greek-Seasoning-002.jpg')

Insert into [Blend](name, ingredients, price, imageUrl)
Values ('Cajun Seasoning', 'Paprika,Garlic Powder,Onion Powder,Thyme,Fennel Seed (optional),Cumin,Cayenne,Salt and Black Pepper',10,'https://www.acouplecooks.com/wp-content/uploads/2020/04/Fajita-Seasoning-003.jpg')


Insert into [Blend](name, ingredients, price, imageUrl)
Values ('Chilly Seasoning', 'Chili Powder (standard, not spicy),Cumin,Dried Oregano,Garlic Powder,Onion Powder',10,'https://www.acouplecooks.com/wp-content/uploads/2020/04/Chili-Seasoning-006.jpg')


Insert into [Blend](name, ingredients, price, imageUrl)
Values ('Chai Spices Blend', 'Cinnamon,Ginger,Cardamom,Black Pepper,Nutmeg,Cloves,Fennel Seed',10,'https://www.acouplecooks.com/wp-content/uploads/2020/09/Vegan-Chai-Latte-005.jpg')
