﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(FrozenUI_IconSlot))]
public class FrozenUI_IconSlotInspector : Editor
{
	public override void OnInspectorGUI()
	{
		EditorGUIUtility.labelWidth = 120f;
		EditorGUILayout.Space();

		DrawTargetSprite();
		DrawDragAndDrop();
		DrawBehaviour();
	}

	public void DrawTargetSprite()
	{
		FrozenUI_IconSlot mSlot = target as FrozenUI_IconSlot;
		
		UITexture iconSprite = EditorGUILayout.ObjectField("Icon Sprite", mSlot.iconSprite, typeof(UITexture), true) as UITexture;
		
		// Set if changed
		if (mSlot.iconSprite != iconSprite)
			mSlot.iconSprite = iconSprite;
	}
	
	public void DrawDragAndDrop()
	{
		FrozenUI_IconSlot mSlot = target as FrozenUI_IconSlot;
		
		bool dragAndDrop = EditorGUILayout.Toggle("Drag and Drop", mSlot.dragAndDropEnabled);
		
		if (mSlot.dragAndDropEnabled != dragAndDrop)
		{
			mSlot.dragAndDropEnabled = dragAndDrop;
		}
		
		// When drag and drop is enabled
		if (mSlot.dragAndDropEnabled)
		{
			bool AllowThrowAway = EditorGUILayout.Toggle("Allow throw away", mSlot.AllowThrowAway);
			bool IsStatic = EditorGUILayout.Toggle("Is Static", mSlot.IsStatic);
			
			if (mSlot.AllowThrowAway != AllowThrowAway || mSlot.IsStatic != IsStatic)
			{
				mSlot.AllowThrowAway = AllowThrowAway;
				mSlot.IsStatic = IsStatic;
			}
			
			if (mSlot.IsStatic)
				EditorGUILayout.HelpBox("Static slots are intended to be used for spell books and such because they will not be unassigned when drag is strated.", MessageType.Warning);
		}
	}
	
	public void DrawBehaviour()
	{
		FrozenUI_IconSlot mSlot = target as FrozenUI_IconSlot;
		
		if (mSlot.GetInternalType() == FrozenUI_IconSlot.InternalType.Normal)
		{
			if (NGUIEditorTools.DrawHeader("Behaviour"))
			{
				NGUIEditorTools.BeginContents();
				EditorGUIUtility.labelWidth = 150f;
				GUILayout.BeginVertical();
				
				// Hover Effect
				FrozenUI_IconSlot.HoverEffectType hoverEffectType = (FrozenUI_IconSlot.HoverEffectType)EditorGUILayout.EnumPopup("Hover Effect Type", mSlot.hoverEffectType);
				
				if (mSlot.hoverEffectType != hoverEffectType)
					mSlot.hoverEffectType = hoverEffectType;
				
				if (mSlot.hoverEffectType == FrozenUI_IconSlot.HoverEffectType.Sprite)
				{
					UISprite hoverEffectSprite = EditorGUILayout.ObjectField("Hover Sprite", mSlot.hoverEffectSprite, typeof(UISprite), true) as UISprite;
					
					if (mSlot.hoverEffectSprite != hoverEffectSprite)
						mSlot.hoverEffectSprite = hoverEffectSprite;
				}
				else if (mSlot.hoverEffectType == FrozenUI_IconSlot.HoverEffectType.Color)
				{
					Color hoverEffectColor = EditorGUILayout.ColorField("Hover Color", mSlot.hoverEffectColor);
					
					if (mSlot.hoverEffectColor != hoverEffectColor)
						mSlot.hoverEffectColor = hoverEffectColor;
				}
				
				// Hover effect speed value
				if (mSlot.hoverEffectType != FrozenUI_IconSlot.HoverEffectType.None)
				{
					float hoverEffectSpeed = EditorGUILayout.FloatField("Hover Tween Duration", mSlot.hoverEffectSpeed);
					
					if (mSlot.hoverEffectSpeed != hoverEffectSpeed)
						mSlot.hoverEffectSpeed = hoverEffectSpeed;
				}
				
				GUILayout.Space(10f);
				GUILayout.EndVertical();
				
				// Press Effect
				FrozenUI_IconSlot.PressEffectType pressEffectType = (FrozenUI_IconSlot.PressEffectType)EditorGUILayout.EnumPopup("Press Effect Type", mSlot.pressEffectType);
				
				if (mSlot.pressEffectType != pressEffectType)
					mSlot.pressEffectType = pressEffectType;
				
				if (mSlot.pressEffectType == FrozenUI_IconSlot.PressEffectType.Sprite)
				{
					UISprite pressEffectSprite = EditorGUILayout.ObjectField("Press Sprite", mSlot.pressEffectSprite, typeof(UISprite), true) as UISprite;
					
					if (mSlot.pressEffectSprite != pressEffectSprite)
						mSlot.pressEffectSprite = pressEffectSprite;
				}
				else if (mSlot.pressEffectType == FrozenUI_IconSlot.PressEffectType.Color)
				{
					Color pressEffectColor = EditorGUILayout.ColorField("Press Color", mSlot.pressEffectColor);
					
					if (mSlot.pressEffectColor != pressEffectColor)
						mSlot.pressEffectColor = pressEffectColor;
				}
				
				// Press effect speed value
				if (mSlot.pressEffectType != FrozenUI_IconSlot.PressEffectType.None)
				{
					float pressEffectSpeed = EditorGUILayout.FloatField("Press Tween Duration", mSlot.pressEffectSpeed);
					
					if (mSlot.pressEffectSpeed != pressEffectSpeed)
						mSlot.pressEffectSpeed = pressEffectSpeed;
					
					bool pressEffectInstaOut = EditorGUILayout.Toggle("Press Tween Insta Out", mSlot.pressEffectInstaOut);
					
					if (mSlot.pressEffectInstaOut != pressEffectInstaOut)
						mSlot.pressEffectInstaOut = pressEffectInstaOut;
				}
				
				NGUIEditorTools.EndContents();
			}
		}
	}
}
