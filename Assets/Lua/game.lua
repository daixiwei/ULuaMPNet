--------------------------------------------------------------------------------
--      Copyright (c) 2015 , Daixiwei daixiwei15@126.com
--------------------------------------------------------------------------------

require "define"
require "functions"
require "TestTransmitter"
require "TestMessageHandler"
require "LoginPanel"

--日志对象--
Log = com.gt.GTLib.GameManager.Log
--网络管理器--
NetManager = com.gt.GTLib.NetManager
AssetManager = com.gt.GTLib.AssetManager
--管理器--
local this;

GameManager = {};

--初始化完成，发送链接服务器信息--
function GameManager.OnInit()
	this = GameManager;
	Log:Info("测试!");

	--测试协同
	coroutine.start(this.InitAssets)
	
end

function GameManager.InitAssets()
	AssetManager:LoadAsset("Prefabs/LoginPanel");
	AssetManager:LoadAsset("Prefabs/MessagePanel");
	AssetManager:LoadAsset("Prefabs/PromptItem");
	AssetManager:LoadAsset("Prefabs/PromptPanel");
	
	AssetManager:BeginLoadEntity();
	
	while AssetManager.Progress<1 do
		coroutine.setp()
		LuaHelper.LoadPanelSlider = AssetManager.Progress;
		Log:Info("setp : " .. AssetManager.Progress)
	end
	
	local parent = LuaHelper.UIRoot;
	local go = LuaHelper.NewPanel(parent,"LoginPanel");
	
	LoginPanel:Show(go);
	
	--注册消息发包器--
	NetManager:AddTransmitter("test",LuaMessageTransmitter.New(1,"TestTransmitter"));
	--注册自定义消息处理--
	TestMessageHandler:Init();
	
	LuaHelper.CloseLoadPanel();
end

--销毁--
function GameManager.OnDestroy()
	--warn('OnDestroy--->>>');
end
