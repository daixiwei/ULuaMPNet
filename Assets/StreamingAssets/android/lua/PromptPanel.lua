require "functions"
require "MessagePanel"

local panel;
local trans;
local baseView;
local gameObject;

local this;
PromptPanel = {};

--启动事件--
function PromptPanel:Show(go)
	this = PromptPanel;
	gameObject = go;
	baseView = gameObject:GetComponent('BaseLua');
	baseView.LuaView = this;
	
	trans = gameObject.transform;
	panel = gameObject:GetComponent('UIPanel');
	--warn("Start lua--->>"..gameObject.name);

	baseView:AddClick('Open');
	this.InitPanel();	--初始化面板--
	NetManager:AddLuaEventListener("c1",this.OnCustomTest);
end

--初始化面板--
function PromptPanel.InitPanel()
	panel.depth = 1;	--设置纵深--
	local parent = trans:Find('ScrollView/Grid');
	--local itemPrefab = prompt:GetGameObject('PromptItem');
	for i = 1, 100 do
		local go = LuaHelper.NewPanel(parent,"PromptItem");
		--local go = newobject(itemPrefab);
		go.name = tostring(i);
		go.transform.parent = parent;
		go.transform.localScale = Vector3.one;
		go.transform.localPosition = Vector3.zero;

		local goo = go.transform:FindChild('Label');
		goo:GetComponent('UILabel').text = i;
	end
	local grid = parent:GetComponent('UIGrid');
	grid:Reposition();
	grid.repositionNow = true;
	--parent:GetComponent('UIWrapGrid'):InitGrid();
end

--单击事件--
function PromptPanel.OnClick()
    TestTransmitter:CustomTest();
end

function PromptPanel.OnCustomTest(parameters)
	local parent = LuaHelper.UIRoot;
	local go = LuaHelper.NewPanel(parent,"MessagePanel");
	MessagePanel:Show(go,parameters["c"]);
end