SET IDENTITY_INSERT PlaceType ON

INSERT INTO dbo.PlaceType
(
    Id,
    Name,
    GName
)
VALUES
( 1, 'Restoranas', 'restaurant' ),
( 2, 'Kavinë', 'cafe' ),
( 3, 'Baras', 'bar' ),
( 4, 'Kepyklëlë', 'bakery' ),
( 5, 'Á namus', 'meal_delivery' ),
( 6, 'Iðsineðimui', 'meal_takeaway' ),
( 7, 'Naktinis klubas', 'night_club' )

SET IDENTITY_INSERT PlaceType OFF