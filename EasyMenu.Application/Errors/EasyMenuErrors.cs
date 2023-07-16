using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EasyMenu.Application.Errors
{
    public enum EasyMenuErrors
    {
        #region User
        [Description("Necessário informar a propriedade (Username)")]
        User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propriedade (Email)")]
        User_Post_BadRequest_Email_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propriedade (Password)")]
        User_Post_BadRequest_Password_Cannot_Be_Null_Or_Empty,

        [Description("Ja existe um usuário cadastraco com esse e-mail")]
        User_Post_BadRequest_Email_Cannot_Be_Duplicated,

        [Description("Usuário ou e-mail inválido ou inexistente")]
        User_Put_BadRequest_User_Not_Found,
        #endregion

        #region Dishes
        [Description("Prato inválido ou inexistente")]
        Dishes_Delete_BadRequest_Dishes_Does_Not_Exists,

        [Description("Prato inválido ou inexistente")]
        Dishes_GetById_BadRequest_Dishes_Does_Not_Exists,

        [Description("Necessário informar a propiedade (Title)")]
        Dishes_Post_BadRequest_Title_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Description)")]
        Dishes_Post_BadRequest_Description_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Price)")]
        Dishes_Post_BadRequest_Price_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Portion)")]
        Dishes_Post_BadRequest_Portion_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (DisheTypeId)")]
        Dishes_Post_BadRequest_DisheTypeId_Does_Not_Exists,

        [Description("Necessário informar a propiedade (Title)")]
        Dishes_Put_BadRequest_Title_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Description)")]
        Dishes_Put_BadRequest_Description_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Price)")]
        Dishes_Put_BadRequest_Price_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Portion)")]
        Dishes_Put_BadRequest_Portion_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (DisheTypeId)")]
        Dishes_Put_BadRequest_DisheTypeId_Does_Not_Exists,

        [Description("Necessário informar a propiedade (CreatedDate)")]
        Dishes_Put_BadRequest_CreatedDate_Cannot_Be_Null_Or_Empty,
        #endregion

        #region DisheType
        [Description("Tipo do prato inválido ou inexistente")]
        DisheType_Delete_BadRequest_DisheType_Does_Not_Exists,

        [Description("Tipo do prato inválido ou inexistente")]
        DisheType_GetById_BadRequest_DisheType_Does_Not_Exists,

        [Description("Necessário informar a propiedade (Title)")]
        DisheType_Post_BadRequest_Title_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Description)")]
        DisheType_Post_BadRequest_Description_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Title)")]
        DisheType_Put_BadRequest_Title_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Description)")]
        DisheType_Put_BadRequest_Description_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (CreatedDate)")]
        DisheType_Put_BadRequest_CreatedDate_Cannot_Be_Null_Or_Empty,
        #endregion

        #region Menu
        [Description("Cardápio inválido ou inexistente")]
        Menu_Delete_BadRequest_Menu_Does_Not_Exists,

        [Description("Cardápio inválido ou inexistente")]
        Menu_GetById_BadRequest_Menu_Does_Not_Exists,

        [Description("Necessário informar a propiedade (Title)")]
        Menu_Post_BadRequest_Title_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Description)")]
        Menu_Post_BadRequest_Description_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Title)")]
        Menu_Put_BadRequest_Title_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Description)")]
        Menu_Put_BadRequest_Description_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (CreatedDate)")]
        Menu_Put_BadRequest_CreatedDate_Cannot_Be_Null_Or_Empty,
        #endregion

        #region MenuOption
        [Description("Opção do cardápio inválido ou inexistente")]
        MenuOption_Delete_BadRequest_MenuOption_Does_Not_Exists,

        [Description("Opção do cardápio inválido ou inexistente")]
        MenuOption_GetById_BadRequest_MenuOption_Does_Not_Exists,

        [Description("Necessário informar a propiedade (MenuId)")]
        MenuOption_Post_BadRequest_MenuId_Does_Not_Exists,

        [Description("Necessário informar a propiedade (DisheId)")]
        MenuOption_Post_BadRequest_DisheId_Does_Not_Exists,

        [Description("Necessário informar a propiedade (MenuId)")]
        MenuOption_Put_BadRequest_MenuId_Does_Not_Exists,

        [Description("Necessário informar a propiedade (DisheId)")]
        MenuOption_Put_BadRequest_DisheId_Does_Not_Exists,
        #endregion

        #region Restaurant
        [Description("Restaurante inválido ou inexistente")]
        Restaurant_Delete_BadRequest_Restaurant_Does_Not_Exists,

        [Description("Restaurante inválido ou inexistente")]
        Restaurant_GetById_BadRequest_Restaurant_Does_Not_Exists,

        [Description("Necessário informar a propiedade (Name)")]
        Restaurant_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Address)")]
        Restaurant_Post_BadRequest_Address_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (MenuId)")]
        Restaurant_Post_BadRequest_MenuId_Does_Not_Exists,

        [Description("Necessário informar a propiedade (Name)")]
        Restaurant_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (Address)")]
        Restaurant_Put_BadRequest_Address_Cannot_Be_Null_Or_Empty,

        [Description("Necessário informar a propiedade (MenuId)")]
        Restaurant_Put_BadRequest_MenuId_Does_Not_Exists,

        [Description("Necessário informar a propiedade (CreatedDate)")]
        Restaurant_Put_BadRequest_CreatedDate_Cannot_Be_Null_Or_Empty,
        #endregion
    }
}
