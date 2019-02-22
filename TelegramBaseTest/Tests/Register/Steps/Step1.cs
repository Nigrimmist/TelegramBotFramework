﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotBase.Base;
using TelegramBotBase.Form;

namespace TelegramBaseTest.Tests.Register.Steps
{
    public class Step1 : AutoCleanForm
    {
        public Data UserData { get; set; }

        public async override Task Init(params object[] args)
        {
            this.UserData = new Data();
        }

        public async override Task Load(MessageResult message)
        {
            if (message.Handled)
                return;

            if (message.MessageText.Trim() == "")
                return;

            if (this.UserData.Firstname == null)
            {
                this.UserData.Firstname = message.MessageText;
                return;
            }
        }

        public async override Task Render(MessageResult message)
        {
            if (this.UserData.Firstname == null)
            {
                await this.Device.Send("Please sent your firstname:");
                return;
            }

            message.Handled = true;

            var step2 = new Step2();

            step2.UserData = this.UserData;

            await this.NavigateTo(step2);
        }

    }
}
