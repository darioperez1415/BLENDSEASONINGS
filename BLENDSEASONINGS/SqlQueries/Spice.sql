-- Grab all rows in Spice Table

select * from [Spice]

 set identity_insert [Spice] On;

 -- Drop table incase need to start over

 drop table [Spice]

 -- Create Table for Spice

Create table [Spice] (
	id int not null identity primary key,
	name varchar (55) not null, 
	weight decimal, 
	price decimal, 
	imageUrl varchar (800)
);

-- Function to Update and change data in a single row

update [Spice]

set 
	name = 'Salt'

where 
	
	id = 1;

-- Spice Table if need to Refresh  

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('1', 'Salt', 10, 10, 'https://www.koyuncusalt.com/images/blog/b-855e18a7d0.jpg')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('2', 'Black Pepper', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpxyDRfVH_qy6sg5MkMS9eKGHH57I0_8xjZnjmePDGeAFqDyh5UwcMlZ-UvTWUpjVMir0&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('3', 'Garlic Powder', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDQMYNjNhiyz5yh-fXnkEx0TxU1vlz-GuR_BC6cgD9JzNB0Q8sqXQMMWQMi4ora7yVJnM&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('4', 'Cayenne Pepper', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2FNskAMgXYK5Y1XKU07ma5KEu0GibVEs5Sw&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('5', 'Ginger Powder', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIv4WxggtLo8XE9IfKrfAdKQlxtzbofZrR3w&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('6', 'Chill Powder', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ-YbTRcCMbLl-e2TZcIcMPh4OGgm8G0V__GB10HDn_MpMn5lkqPvAVj_5cTyPr0P42xcs&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('7', 'Jerk Seasoning', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTx2rK4sDH5zD8lfMVhYr7_LQwSqP20yj5JuQ&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('8', 'Cajun Seasoning', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSVip2jHH546RsmoWFuM-GGl8ertJJuCHoNlg&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('9', 'Thyme', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS6rP9YrhYZr5186fGDmncASGjv-us1FZ5P4Q&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('10', 'Basil', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS59jPWZD_vDmXv-qQyC5txF0Wf5U0D72r0Ow&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('11', 'Sugar', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCotm7D643_d17sa7shB2o2PrPzc5Q5erDqNKT7hR70Scp_zUaGBK7kf2U-KE-KZw0kek&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('12', 'Turmeric powder', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbnXUESFj4yTTS6k0Rfu-GGRN7J1-4YjcqNXVze7zeHtot8Y7S4Vdxa3PDDre9Bu3iBZo&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('13', 'Onion powder', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTv0SLkPGN_bIgNk8CS2VHFJNXZLS37lbVT2w&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('14', 'Nutmeg grounded', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ8vFfXBAE6XsCf78r4QLFDqq_OGbH1xcG-Zw&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('15', 'Coriander', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4fAEcPNHi333sMA7rPaCBNvjoqfIDa_6IyA&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('16', 'Oregano', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ5wmhePdq2DEXP89nef9AxuVlIBZ4AUXMMVw&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('17', 'Cinnamon', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ_fs9nXULR1KnL3JgQNPmK1SH2HesbxxlaKg&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('18', 'Paprika', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4A1g8pJ9FlMbESkiPA158O84SYRjLdzdJxA&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('19', 'Cloves', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQc2wZJ0g3E1hda9XOyyPRyy_wN2_IY5WgDYQ&usqp=CAU')

INSERT INTO [Spice] (id, name, weight, price, imageUrl)
	VALUES ('20', 'Sage', 10, 10, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQY4sBLffXMvdSFoVLz9F64ETNbifgSZKbpsw&usqp=CAU')
