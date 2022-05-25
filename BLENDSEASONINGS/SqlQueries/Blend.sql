--Create new Table for Blend

Create Table [Blend](
  id int not null identity primary key, 
  name varchar (55),
  weight decimal
)

-- Look up Blend

Select * from [Blend]

-- Drop Blend table and restart
Drop table [Blend]

-- Blend Insert statements

Insert into [Blend](name, weight)
Values ('Fish Blend', 30)

Insert into [Blend](name, weight)
Values ('Itilian Blend', 40)

Insert into [Blend](name, weight)
Values ('Asian Blend', 30)