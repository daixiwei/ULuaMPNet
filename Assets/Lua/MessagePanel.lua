require "functions"

local this;
local gameObject;
MessagePanel = {};

--启动事件--发送登录请求--
function MessagePanel:Show(go,message)
	this = MessagePanel;
	gameObject = go;

	local panel = gameObject:GetComponent('UIPanel');
	panel.depth = 10;	--设置纵深--
	
	local goo = go.transform:FindChild('Label');
	goo:GetComponent('UILabel').text = "服务器消息 : " .. message;
	
	local Button = find('Button');
	UIEventListener.Get(Button).onClick = LuaHelper.VoidDelegate(this.OnClick);
end

--单击事件--
function MessagePanel.OnClick()
	destroy(gameObject);
end

