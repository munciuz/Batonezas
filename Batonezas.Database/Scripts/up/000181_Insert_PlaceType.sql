SET IDENTITY_INSERT PlaceType ON

INSERT INTO dbo.PlaceType
(
    Id,
    Name,
    GName
)
VALUES
( 1, 'Restoranas', 'restaurant' ),
( 2, 'Kavin�', 'cafe' ),
( 3, 'Baras', 'bar' ),
( 4, 'Kepykl�l�', 'bakery' ),
( 5, '� namus', 'meal_delivery' ),
( 6, 'I�sine�imui', 'meal_takeaway' ),
( 7, 'Naktinis klubas', 'night_club' )

SET IDENTITY_INSERT PlaceType OFF