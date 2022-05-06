-- copy table data --
	  -- course --
	UPDATE CourseTBL
	SET CourseTBL.Course = OutlineDataTBL.Course
	FROM OutlineDataTBL, CourseTBL
	--WHERE OutlineDataTBL.Id = CourseTBL.Id
	  -- unit --
	UPDATE UnitTBL
	SET UnitTBL.Unit = OutlineDataTBL.Unit
	FROM OutlineDataTBL, UnitTBL
	--WHERE OutlineDataTBL.Id = UnitTBL.Id