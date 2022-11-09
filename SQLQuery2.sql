SELECT Blend.name, Blend.weight, Blend.id, Ingredient.blendId, Ingredient.spiceId, 
                                                Spice.id as SpiceId, Spice.imageUrl, Spice.name as SpiceName, Spice.price, Spice.weight as SpiceWeight
                                                FROM [Blend]
                                                INNER JOIN Ingredient
                                                On Blend.id = Ingredient.blendId
                                                INNER JOIN Spice
                                                ON Ingredient.spiceId = Spice.id
                                                WHERE Blend.id = 1