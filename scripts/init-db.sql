/* create tables */

CREATE TABLE "Coordinates" (
	id INT PRIMARY KEY,
	latitude DOUBLE PRECISION NOT NULL,
	longitude DOUBLE PRECISION NOT NULL
);

CREATE TABLE "BuildingAddresses" (
    	id INT PRIMARY KEY,
    	description TEXT,
    	coordinates_id INT NOT NULL,
	CONSTRAINT BuildingAddresses_coordinates_id_ukey UNIQUE (coordinates_id)
);

CREATE TABLE "BuildingTypes" (
	id INT PRIMARY KEY,
	type VARCHAR(70),
  	marker_path VARCHAR(100),
  	CONSTRAINT BuildingTypes_marker_path_ukey UNIQUE (marker_path)
);

CREATE TABLE "Buildings" (
	id INT PRIMARY KEY,
	inventory_usrre_number VARCHAR(100) NOT NULL,
	name VARCHAR(200) NOT NULL,
	address_id INT NOT NULL,
	type_id INT NOT NULL,
	CONSTRAINT Buildings_address_id_ukey UNIQUE (address_id)
);

CREATE TABLE "Photos" (
	id INT PRIMARY KEY,
    	description VARCHAR(1200),
	image_path VARCHAR(100),
	building_id INT NOT NULL
);

CREATE TABLE "Categories" (
	id INT PRIMARY KEY,
	name VARCHAR(70) NOT NULL
);

CREATE TABLE "StructuralObjects" (
	id INT PRIMARY KEY,
	subdivision VARCHAR(500) NOT NULL,
	category_id INT NOT NULL,
	building_id INT NOT NULL,
	description TEXT,
	website VARCHAR(500)
);

CREATE TABLE "StructuralObjectsIcons" (
  	structural_object_id INT PRIMARY KEY,
  	subdivision VARCHAR(500) NOT NULL,
  	logo_path VARCHAR(100)
);

CREATE TABLE "Scientists" (
    	id SERIAL PRIMARY KEY,
    	first_name VARCHAR(50) NOT NULL,
    	last_name VARCHAR(50) NOT NULL,
	patronymic VARCHAR(50),
	biography TEXT,
	birth_date DATE NOT NULL,
	death_date DATE,
	CONSTRAINT dates_comparison CHECK (death_date IS NULL OR birth_date < death_date)	
);

CREATE TABLE "ScientistPhotos" (
	id INT PRIMARY KEY,
    	title VARCHAR(100),
    	image_path VARCHAR(100),
	scientist_id INT NOT NULL
);

CREATE TABLE "ScientistDocs" (
	id INT PRIMARY KEY,
    	title VARCHAR(100),
    	file_path VARCHAR(100),
	scientist_id INT NOT NULL
);

CREATE TABLE "MemoryPlaces" (
	id INT PRIMARY KEY,
	ordinal_number INT NOT NULL,
	name VARCHAR(200) NOT NULL,
	description TEXT,
	coordinates_id INT NOT NULL,
	scientist_id INT NOT NULL,
	CONSTRAINT MemoryPlaces_coordinates_id_ukey UNIQUE (coordinates_id)
);

CREATE TABLE "MemoryPhotos" (
    	id INT PRIMARY KEY,
	ordinal_number INT NOT NULL,
    	description VARCHAR(1200),
    	image_path VARCHAR(100),
	memory_place_id INT NOT NULL
);

CREATE TABLE "MemoryDocs" (
    	id INT PRIMARY KEY,
    	title VARCHAR(100),
    	file_path VARCHAR(100),
	memory_place_id INT NOT NULL
);

/* add relationships */

ALTER TABLE "BuildingAddresses"
    	ADD FOREIGN KEY (coordinates_id) REFERENCES "Coordinates" (id)
        	ON DELETE CASCADE
       		DEFERRABLE INITIALLY DEFERRED;
	
ALTER TABLE "Buildings"
    	ADD FOREIGN KEY (address_id) REFERENCES "BuildingAddresses" (id)
		ON DELETE CASCADE
		DEFERRABLE INITIALLY DEFERRED,
	ADD FOREIGN KEY (type_id) REFERENCES "BuildingTypes" (id)
		ON DELETE CASCADE
		DEFERRABLE INITIALLY DEFERRED;
	
ALTER TABLE "Photos"
	ADD FOREIGN KEY (building_id) REFERENCES "Buildings" (id)
		ON DELETE CASCADE
		DEFERRABLE INITIALLY DEFERRED;

ALTER TABLE "StructuralObjects"
	ADD FOREIGN KEY (category_id) REFERENCES "Categories" (id)
        	ON DELETE CASCADE
        	DEFERRABLE INITIALLY DEFERRED,
	ADD FOREIGN KEY (building_id) REFERENCES "Buildings" (id)
        	ON DELETE CASCADE
        	DEFERRABLE INITIALLY DEFERRED;

ALTER TABLE "StructuralObjectsIcons"
	ADD FOREIGN KEY (structural_object_id) REFERENCES "StructuralObjects" (id)
		ON DELETE CASCADE
		DEFERRABLE INITIALLY DEFERRED;

ALTER TABLE "ScientistPhotos"
	ADD FOREIGN KEY (scientist_id) REFERENCES "Scientists" (id)
		ON DELETE CASCADE
		DEFERRABLE INITIALLY DEFERRED;

ALTER TABLE "ScientistDocs"
	ADD FOREIGN KEY (scientist_id) REFERENCES "Scientists" (id)
		ON DELETE CASCADE
		DEFERRABLE INITIALLY DEFERRED;

ALTER TABLE "MemoryPlaces"
	ADD FOREIGN KEY (coordinates_id) REFERENCES "Coordinates" (id)
        	ON DELETE CASCADE
        	DEFERRABLE INITIALLY DEFERRED,
	ADD FOREIGN KEY (scientist_id) REFERENCES "Scientists" (id)
		ON DELETE CASCADE
		DEFERRABLE INITIALLY DEFERRED;

ALTER TABLE "MemoryPhotos"
	ADD FOREIGN KEY (memory_place_id) REFERENCES "MemoryPlaces" (id)
		ON DELETE CASCADE
		DEFERRABLE INITIALLY DEFERRED;

ALTER TABLE "MemoryDocs"
	ADD FOREIGN KEY (memory_place_id) REFERENCES "MemoryPlaces" (id)
		ON DELETE CASCADE
		DEFERRABLE INITIALLY DEFERRED;

/* add triggers */

CREATE OR REPLACE FUNCTION delete_coordinates()
RETURNS TRIGGER
AS $$
BEGIN
    DELETE FROM public."Coordinates"
    WHERE id = OLD.coordinates_id;
    RETURN NULL;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE TRIGGER delete_coordinates_MP
AFTER DELETE ON public."MemoryPlaces"
FOR EACH ROW
EXECUTE FUNCTION delete_coordinates();

CREATE OR REPLACE TRIGGER delete_coordinates_B
AFTER DELETE ON public."BuildingAddresses"
FOR EACH ROW
EXECUTE FUNCTION delete_coordinates();

