SELECT * FROM Blend

SELECT * FROM Ingredient

SELECT * FROM Spice

SELECT * FROM [Order]

SELECT * FROM [User]

-- Order by Blend ID
-- Order by Blend
-- Track ingredients
-- 

SELECT Blend.name, Blend.weight, Blend.id, Ingredient.blendId, Ingredient.spiceId, 
Spice.id, Spice.imageUrl, Spice.name, Spice.price, Spice.weight
FROM Blend
INNER JOIN Ingredient
On Blend.id = Ingredient.blendId
INNER JOIN Spice
ON Ingredient.spiceId = Spice.id
Order by Blend.id


SELECT Ingredient.blendId, Ingredient.spiceId,
Spice.id, Spice.imageUrl, Spice.name, Spice.price, Spice.weight
FROM Ingredient
INNER JOIN Spice
On Ingredient.spiceId = Spice.id