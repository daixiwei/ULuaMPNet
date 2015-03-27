Map ={}

setmetatable(Map, Map)

function Map:New()
	local self ={};
	setmetatable(self, Map);  
	return self;
end