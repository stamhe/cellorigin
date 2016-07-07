﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class PeerManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PeerManager), typeof(Singleton<PeerManager>));
		L.RegFunction("Get", Get);
		L.RegFunction("New", _CreatePeerManager);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("MsgMeta", get_MsgMeta, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePeerManager(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				PeerManager obj = new PeerManager();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: PeerManager.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Get(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PeerManager obj = (PeerManager)ToLua.CheckObject(L, 1, typeof(PeerManager));
			string arg0 = ToLua.CheckString(L, 2);
			NetworkPeer o = obj.Get(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		object obj = ToLua.ToObject(L, 1);

		if (obj != null)
		{
			LuaDLL.lua_pushstring(L, obj.ToString());
		}
		else
		{
			LuaDLL.lua_pushnil(L);
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MsgMeta(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PeerManager obj = (PeerManager)o;
			MessageMetaSet ret = obj.MsgMeta;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index MsgMeta on a nil value" : e.Message);
		}
	}
}
