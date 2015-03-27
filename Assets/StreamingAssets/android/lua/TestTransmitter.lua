--------------------------------------------------------------------------------
--      Copyright (c) 2015 , Daixiwei daixiwei15@126.com
--------------------------------------------------------------------------------

NetManager = com.gt.GTLib.NetManager
MPObject = com.gt.entities.MPObject

TestTransmitter = {}

local transmitter;
local this;
-- 对应的连接器id--
local connecterId=1;

--连接服务器--
function TestTransmitter:Connect(ip,port) 
	this = TestTransmitter;
	transmitter = NetManager:GetTransmitter("test");
	transmitter:Connect(ip,port);
	return this;
end

--登陆服务器--
function TestTransmitter:Login(uname,pw)
	transmitter:Login(uname,pw);
end

--测试自定义包--
function TestTransmitter:CustomTest()
	local mpo = MPObject.New();
	mpo:PutUtfString("s","hello server!");
	--mpo:PutInt("a",234);
	--mpo:PutByte("b",100);
	--mpo:PutShort("c",10000);
	--mpo:PutLong("d",2000000);
	--mpo:PutFloat("e",12.24);
	--mpo:PutDouble("f",454545.334353);
	--mytable["s"] ="hello server!";
	transmitter:SendExtensionRequest("test",mpo,false);
end
