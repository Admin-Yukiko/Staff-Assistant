﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3074
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Nightscape_Staff_Assistant.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        Friend ReadOnly Property about_image() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("about_image", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to C=Doors
        '''S=Metal Doors
        '''I=Short Metal Door (N/SW L CW)                      0675
        '''I=Short Metal Door (N/SE R CCW)                     0677
        '''I=Short Metal Door (W/SE L CW)                      067D
        '''I=Short Metal Door (W/NE R CCW)                     067F
        '''I=Tall Metal Door (N/SW L CW)                       06C5
        '''I=Tall Metal Door (N/SE R CCW)                      06C7
        '''I=Tall Metal Door (W/SE L CW)                       06CD
        '''I=Tall Metal Door (W/NE R CCW)                      06CF
        '''I=Barred Metal Door (N/S [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property building_materials() As String
            Get
                Return ResourceManager.GetString("building_materials", resourceCulture)
            End Get
        End Property
        
        Friend ReadOnly Property cancel() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("cancel", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property ControlPanel2() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("ControlPanel2", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property downarrow() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("downarrow", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property fast_forward() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("fast_forward", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property folder_man() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("folder_man", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property forward() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("forward", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to G=Accessories for Town and Homes
        '''C=Light Sources
        '''S=Lamp Posts
        '''I=Plain Square Lamp Post (Lit)                      0B20
        '''I=Plain Square Lamp Post (Unlit)                    0B21
        '''I=Plain Rounded Lamp Post (Lit)                     0B22
        '''I=Plain Rounded Lamp Post (Unlit)                   0B23
        '''I=Fancy Lamp Post (Lit)                             0B24
        '''I=Fancy Lamp Post (Unlit)                           0B25
        '''S=Candles
        '''I=Small Candle (Lit)                                1434
        '''I=Burnt Out Candle             [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property items_list() As String
            Get
                Return ResourceManager.GetString("items_list", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to C=GameMaster
        '''S=Jails
        '''I=Jail Cell #01                                     5276,1164,0
        '''I=Jail Cell #02                                     5286,1164,0
        '''I=Jail Cell #03                                     5296,1164,0
        '''I=Jail Cell #04                                     5306,1164,0
        '''I=Jail Cell #05                                     5276,1174,0
        '''I=Jail Cell #06                                     5286,1174,0
        '''I=Jail Cell #07                                     5296,1174,0
        '''I=Jail Cell #08                    [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property locations_list() As String
            Get
                Return ResourceManager.GetString("locations_list", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to G=Animals
        '''S=Arctic Animal
        '''N=frostwolf
        '''B=00e1
        '''C=2460
        '''N=polar
        '''B=00d5
        '''C=0
        '''N=walrus
        '''B=00dd
        '''C=0
        '''S=Desert
        '''N=snake
        '''B=0034
        '''C=0
        '''N=firelizard
        '''B=00ce
        '''C=0x66d
        '''N=gargoyle
        '''B=0004
        '''C=0
        '''N=giant_serpent
        '''B=0015
        '''C=0
        '''N=imp
        '''B=0027
        '''C=0
        '''N=mongbat
        '''B=0027
        '''C=0
        '''N=scorpion
        '''B=0030
        '''C=0
        '''N=spider
        '''B=001c
        '''C=0
        '''N=stonegargoyle
        '''B=0004
        '''C=900
        '''S=Domestic Animal
        '''N=bull
        '''B=00e9
        '''C=0
        '''N=cat
        '''B=00c9
        '''C=0
        '''N=chicken
        '''B=00d0
        '''C=0
        '''N=cow
        '''B=00d8
        '''C=0
        '''N=dog
        '''B=00d9
        '''C=0
        '''N=goat
        '''B=00d1
        '''C=0
        '''N=horse
        '''B=00cc
        '''C=0
        '''N [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property npc_list() As String
            Get
                Return ResourceManager.GetString("npc_list", resourceCulture)
            End Get
        End Property
        
        Friend ReadOnly Property package_application() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("package_application", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property play() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("play", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property reverse() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("reverse", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property rewind() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("rewind", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property services() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("services", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property splash_screen() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("splash_screen", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property stop_icon() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("stop_icon", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property unused_tile() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("unused_tile", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property window_new() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("window_new", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace
