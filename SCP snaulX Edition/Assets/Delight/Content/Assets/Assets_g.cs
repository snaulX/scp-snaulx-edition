// Asset data and providers generated from asset content
#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{

    #region Sprites

    /// <summary>
    /// Manages a UnityEngine.Sprite object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
    public partial class SpriteAsset : AssetObject<UnityEngine.Sprite>
    {
        public static implicit operator SpriteAsset(UnityEngine.Sprite unityObject)
        {
            return new SpriteAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator SpriteAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.Sprites[assetId];
        }
    }

    /// <summary>
    /// SpriteAsset data provider. Contains references to all sprites in the project.
    /// </summary>
    public partial class SpriteAssetData : DataProvider<SpriteAsset>
    {
        #region Fields

        public readonly SpriteAsset CheckBox;
        public readonly SpriteAsset Selection;
        public readonly SpriteAsset RadioButtonPressed;
        public readonly SpriteAsset ListSelection;
        public readonly SpriteAsset ComboBoxButton;
        public readonly SpriteAsset CloseButton;
        public readonly SpriteAsset RadioButton;
        public readonly SpriteAsset ComboBoxButtonPressed;
        public readonly SpriteAsset CheckBoxPressed;
        public readonly SpriteAsset RainbowSquare;

        #endregion

        #region Constructor

        public SpriteAssetData()
        {
            CheckBox = new SpriteAsset { Id = "CheckBox", IsResource = true, RelativePath = "Sprites/" };
            Selection = new SpriteAsset { Id = "Selection", IsResource = true, RelativePath = "Sprites/" };
            RadioButtonPressed = new SpriteAsset { Id = "RadioButtonPressed", IsResource = true, RelativePath = "Sprites/" };
            ListSelection = new SpriteAsset { Id = "ListSelection", IsResource = true, RelativePath = "Sprites/" };
            ComboBoxButton = new SpriteAsset { Id = "ComboBoxButton", IsResource = true, RelativePath = "Sprites/" };
            CloseButton = new SpriteAsset { Id = "CloseButton", IsResource = true, RelativePath = "Sprites/" };
            RadioButton = new SpriteAsset { Id = "RadioButton", IsResource = true, RelativePath = "Sprites/" };
            ComboBoxButtonPressed = new SpriteAsset { Id = "ComboBoxButtonPressed", IsResource = true, RelativePath = "Sprites/" };
            CheckBoxPressed = new SpriteAsset { Id = "CheckBoxPressed", IsResource = true, RelativePath = "Sprites/" };
            RainbowSquare = new SpriteAsset { Id = "RainbowSquare", IsResource = true, RelativePath = "Sprites/" };

            Add(CheckBox);
            Add(Selection);
            Add(RadioButtonPressed);
            Add(ListSelection);
            Add(ComboBoxButton);
            Add(CloseButton);
            Add(RadioButton);
            Add(ComboBoxButtonPressed);
            Add(CheckBoxPressed);
            Add(RainbowSquare);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static SpriteAssetData Sprites = new SpriteAssetData();
    }

    #endregion

    #region Materials

    /// <summary>
    /// Manages a UnityEngine.Material object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
    public partial class MaterialAsset : AssetObject<UnityEngine.Material>
    {
        public static implicit operator MaterialAsset(UnityEngine.Material unityObject)
        {
            return new MaterialAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator MaterialAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.Materials[assetId];
        }
    }

    /// <summary>
    /// MaterialAsset data provider. Contains references to all materials in the project.
    /// </summary>
    public partial class MaterialAssetData : DataProvider<MaterialAsset>
    {
        #region Fields

        public readonly MaterialAsset UIFastDefault;

        #endregion

        #region Constructor

        public MaterialAssetData()
        {
            UIFastDefault = new MaterialAsset { Id = "UI-Fast-Default", IsResource = true, RelativePath = "Materials/" };

            Add(UIFastDefault);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static MaterialAssetData Materials = new MaterialAssetData();
    }

    #endregion

    #region Fonts

    /// <summary>
    /// Manages a UnityEngine.Font object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
    public partial class FontAsset : AssetObject<UnityEngine.Font>
    {
        public static implicit operator FontAsset(UnityEngine.Font unityObject)
        {
            return new FontAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator FontAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.Fonts[assetId];
        }
    }

    /// <summary>
    /// FontAsset data provider. Contains references to all fonts in the project.
    /// </summary>
    public partial class FontAssetData : DataProvider<FontAsset>
    {
        #region Fields

        public readonly FontAsset InconsolataRegular;

        #endregion

        #region Constructor

        public FontAssetData()
        {
            InconsolataRegular = new FontAsset { Id = "Inconsolata-Regular", IsResource = true, RelativePath = "Fonts/" };

            Add(InconsolataRegular);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static FontAssetData Fonts = new FontAssetData();
    }

    #endregion

    #region Shaders

    /// <summary>
    /// Manages a UnityEngine.Shader object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
    public partial class ShaderAsset : AssetObject<UnityEngine.Shader>
    {
        public static implicit operator ShaderAsset(UnityEngine.Shader unityObject)
        {
            return new ShaderAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator ShaderAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.Shaders[assetId];
        }
    }

    /// <summary>
    /// ShaderAsset data provider. Contains references to all shaders in the project.
    /// </summary>
    public partial class ShaderAssetData : DataProvider<ShaderAsset>
    {
        #region Fields

        public readonly ShaderAsset UIFastDefault;

        #endregion

        #region Constructor

        public ShaderAssetData()
        {
            UIFastDefault = new ShaderAsset { Id = "UI-Fast-Default", IsResource = true, RelativePath = "Shaders/" };

            Add(UIFastDefault);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static ShaderAssetData Shaders = new ShaderAssetData();
    }

    #endregion

    #region TMP_FontAssets

    /// <summary>
    /// Manages a TMPro.TMP_FontAsset object. Loads/unloads the asset on-demand as it's requested by views.
    /// </summary>
    public partial class TMP_FontAsset : AssetObject<TMPro.TMP_FontAsset>
    {
        public static implicit operator TMP_FontAsset(TMPro.TMP_FontAsset unityObject)
        {
            return new TMP_FontAsset { UnityObject = unityObject, IsUnmanaged = true };
        }

        public static implicit operator TMP_FontAsset(string assetId)
        {
            if (String.IsNullOrEmpty(assetId))
                return null;

            if (assetId.StartsWith("?"))
                assetId = assetId.Substring(1);

            return Assets.TMP_FontAssets[assetId];
        }
    }

    /// <summary>
    /// TMP_FontAsset data provider. Contains references to all tmp_fontassets in the project.
    /// </summary>
    public partial class TMP_FontAssetData : DataProvider<TMP_FontAsset>
    {
        #region Fields

        public readonly TMP_FontAsset InconsolataRegularSDF;

        #endregion

        #region Constructor

        public TMP_FontAssetData()
        {
            InconsolataRegularSDF = new TMP_FontAsset { Id = "Inconsolata-Regular SDF", IsResource = true, RelativePath = "Fonts/" };

            Add(InconsolataRegularSDF);
        }

        #endregion
    }

    public static partial class Assets
    {
        public static TMP_FontAssetData TMP_FontAssets = new TMP_FontAssetData();
    }

    #endregion
}
