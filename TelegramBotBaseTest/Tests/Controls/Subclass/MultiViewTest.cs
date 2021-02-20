﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBotBase.Args;
using TelegramBotBase.Base;
using TelegramBotBase.Form;

namespace TelegramBotBaseTest.Tests.Controls.Subclass
{
    public class MultiViewTest : TelegramBotBase.Controls.Hybrid.MultiView
    {


        public override async Task Action(MessageResult result, string value = null)
        {
         
            switch(result.RawData)
            {
                case "back":

                    this.SelectedViewIndex--;

                    break;
                case "next":

                    this.SelectedViewIndex++;

                    break;
            }

        }

        public override async Task RenderView(RenderViewEventArgs e)
        {

            ButtonForm bf = new ButtonForm();
            bf.AddButtonRow(new ButtonBase("Back", "back"), new ButtonBase("Next", "next"));

            switch(e.CurrentView)
            {
                case 0:

                    await Device.Send("Page 1", bf);

                    break;

                case 1:

                    await Device.Send("Page 2", bf);

                    break;

                case 2:

                    await Device.Send("Page 3", bf);

                    break;

                default:

                    await Device.Send("Unknown Page", bf);

                    break;


            }

        }



    }
}
