--------------------------------------------------------------------------------
--      Copyright (c) 2015 , Daixiwei daixiwei15@126.com
--------------------------------------------------------------------------------

NetManager = com.gt.GTLib.NetManager
MPObject = com.gt.entities.MPObject
Log = com.gt.GTLib.GameManager.Log

TestMessageHandler = {}

local this;
local connecterId=1;


function TestMessageHandler:Init()
	this = TestMessageHandler;
	
	--注自定义消息包处理--
	NetManager:AddLuaMessageHandler(1,"test",this.Test);
	
end

--连接服务器--
function TestMessageHandler.Test(parameters)
	--Log:Info("test:" .. parameters["c"]);
	NetManager:DispatchLuaEvent("c1",parameters);
end
