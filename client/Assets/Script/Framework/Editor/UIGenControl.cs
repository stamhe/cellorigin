﻿using System.Reflection;

namespace Framework
{
    /// <summary>
    /// 一个窗口上的一系列控件
    /// </summary>
    class UIGenControl
    {
        UIGenWindow _window;

        DataContext _binder;

        public UIGenControl(UIGenWindow win, DataContext binder)
        {
            _binder = binder;
            _window = win;
        }

        public ObjectDetectType ObjectType
        {
            get { return _binder.Type; }
        }

        public void PrintDeclareCode(CodeGenerator gen)
        {
            gen.PrintLine(GetVarType(), " _", Name, ";");
        }

        public void PrintAttachCode(CodeGenerator gen)
        {
            var path = ObjectUtility.GetGameObjectPath(_binder.gameObject, _window.Obj);
            gen.PrintLine("_", Name, " = trans.Find(\"", path, "\").GetComponent<", GetVarType(), ">();");
        }


        public void PrintButtonClickRegisterCode(CodeGenerator gen)
        {
            if (_binder.Type != ObjectDetectType.GenAsButton)
                return;

            gen.PrintLine("_", Name, ".onClick.AddListener( ", ButtonCallbackName, " );");
        }

        public string ButtonCallbackName
        {
            get
            {
                return Name + "_Click";
            }
        }

        public bool ButtonCallbackExists
        {
            get
            {
                // 加载游戏的二进制
                var ass = Assembly.LoadFile(@"Library\ScriptAssemblies\Assembly-CSharp.dll");

                // 取到类信息
                var classInfo = ass.GetType(_window.Name);

                if (classInfo == null)
                    return false;

                // 取方法, 查方法是否存在
                var methodInfo = classInfo.GetMethod(ButtonCallbackName, BindingFlags.NonPublic | BindingFlags.Instance);

                return methodInfo != null;
            }
        }

        public void PrintButtonClickImplementCode(CodeGenerator gen)
        {
            if (_binder.Type != ObjectDetectType.GenAsButton)
                return;

            var path = ObjectUtility.GetGameObjectPath(_binder.gameObject, _window.Obj);

            gen.PrintLine("// Button @ ", path);
            gen.PrintLine("void ", ButtonCallbackName, "( )");
            gen.PrintLine("{");
            gen.PrintLine();
            gen.PrintLine("}");
            gen.PrintLine();
        }

        // TODO 处理名字不符合函数命名规定的问题
        public string Name
        {
            get { return _binder.gameObject.name; }
        }

        string GetVarType()
        {
            switch (_binder.Type)
            {
                case ObjectDetectType.GenAsButton:
                    return "Button";
                case ObjectDetectType.GenAsText:
                    return "Text";
                case ObjectDetectType.GenAsInputField:
                    return "InputField";
                case ObjectDetectType.GenAsImage:
                    return "Image";
                case ObjectDetectType.GenAsDropdown:
                    return "Dropdown";
            }

            return "Unknown";
        }
    }

}