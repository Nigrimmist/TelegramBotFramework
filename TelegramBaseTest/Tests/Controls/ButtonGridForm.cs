﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotBase.Controls;
using TelegramBotBase.Form;

namespace TelegramBaseTest.Tests.Controls
{
    public class ButtonGridForm : AutoCleanForm
    {

        ButtonGrid m_Buttons = null;

        public ButtonGridForm()
        {
            this.DeleteMode = TelegramBotBase.Enums.eDeleteMode.OnLeavingForm;

            this.Init += ButtonGridForm_Init;
        }

        private async Task ButtonGridForm_Init(object sender, TelegramBotBase.Base.InitEventArgs e)
        {
            m_Buttons = new ButtonGrid();

            await m_Buttons.SetKeyboardType(TelegramBotBase.Enums.eKeyboardType.InlineKeyBoard);

            ButtonForm bf = new ButtonForm();

            bf.AddButtonRow(new ButtonBase("Back", "back"), new ButtonBase("Switch Keyboard", "switch"));

            bf.AddButtonRow(new ButtonBase("Button1", "b1"), new ButtonBase("Button2", "b2"));

            bf.AddButtonRow(new ButtonBase("Button3", "b3"), new ButtonBase("Button4", "b4"));

            m_Buttons.ButtonsForm = bf;

            m_Buttons.ButtonClicked += Bg_ButtonClicked;

            this.AddControl(m_Buttons);


        }

        private async void Bg_ButtonClicked(object sender, TelegramBotBase.Base.ButtonClickedEventArgs e)
        {
            if (e.Button == null)
                return;

            if (e.Button.Value == "back")
            {
                var start = new Start();
                await this.NavigateTo(start);
            }
            else if (e.Button.Value == "switch")
            {
                switch (m_Buttons.KeyboardType)
                {
                    case TelegramBotBase.Enums.eKeyboardType.ReplyKeyboard:
                        await m_Buttons.SetKeyboardType(TelegramBotBase.Enums.eKeyboardType.InlineKeyBoard);
                        break;
                    case TelegramBotBase.Enums.eKeyboardType.InlineKeyBoard:
                        await m_Buttons.SetKeyboardType(TelegramBotBase.Enums.eKeyboardType.ReplyKeyboard);
                        break;
                }


            }
            else
            {

                await this.Device.Send($"Button clicked with Text: {e.Button.Text} and Value {e.Button.Value}");
            }


        }
    }
}
