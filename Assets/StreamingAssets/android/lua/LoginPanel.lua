require "functions"
require "PromptPanel" 

LoginPanel ={};
NetManager = com.gt.GTLib.NetManager

local baseView;
local trans;
local gameObject;
local this;
local button;

function LoginPanel:Show(go)
	this = LoginPanel;
	gameObject = go;
	baseView = go:GetComponent("BaseLua");
	baseView.LuaView = this;
	
	trans = go.transform;
	button = trans:Find("Button").gameObject;
	--LuaUIEventListener.Get(button).onClick  = this.OnClick;
	--UIEventListener.Get(Button).onClick = LuaHelper.VoidDelegate(this.OnClick);
	baseView:AddClick("Button");
end

local userName;
local passWd;

function LoginPanel.OnClick()
	button:SetActive(false);
	local UserNameInput = trans:Find("UserNameInput"):GetComponent("UIInput");
	local PassWdInput = trans:Find("PassWdInput"):GetComponent("UIInput");
	--连接服务器--
	TestTransmitter:Connect("127.0.0.1",9934);
	--添加事件--
	NetManager:AddLuaEventListener("conn1",this.OnConnect);
	--测试删除事件--
	--NetManager:RemoveLuaEventListener("conn1",this.OnConnect);
	NetManager:AddLuaEventListener("lost1",this.OnLost);
	NetManager:AddLuaEventListener("login1",this.OnLogin);
	NetManager:AddLuaEventListener("le1",this.OnLoginFail);
	
	userName = UserNameInput.value;
	passWd = PassWdInput.value;
end

--连接事件处理--
function LoginPanel.OnConnect(evt)
	Log:Info("连接成功!");
	TestTransmitter:Login(userName,passWd);
end

--连接失败事件处理--
function LoginPanel.OnLost()
	Log:Info("连接失败!");
	button:SetActive(true);
	NetManager:RemoveAllLuaEventListeners();
end

--登陆成功事件处理--
function LoginPanel.OnLogin()
	Log:Info("登陆成功!");
	destroy(gameObject);
	local parent = LuaHelper.UIRoot;
	local go = LuaHelper.NewPanel(parent,"PromptPanel");
	PromptPanel:Show(go);
	--TestTransmitter:CustomTest();
end

--登陆失败事件处理--
function LoginPanel.OnLoginFail()
	button:SetActive(true);
	Log:Info("登陆失败!");
end

