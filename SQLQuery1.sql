Select * from Ingredient

Select * from Blend

select * from Spice

Select Ingredient.id, Ingredient.blendId, Ingredient.spiceId,Spice.id, Spice.name, Spice.weight, Spice.price, Spice.imageUrl
From Ingredient
Right join Spice
ON Ingredient.id = Spice.id
Union
Select Blend.id, Blend.name,Ingredient.id, Ingredient.blendId,Ingredient.spiceId
From Blend
Left Join Ingredient
ON Blend.id = Ingredient.blendId


Select Blend.id, Blend.name,Blend.weight
From Blend
Inner Join Ingredient
ON Blend.id = Ingredient.id
Inner Join Spice 
On Ingredient.blendId = Ingredient.id
