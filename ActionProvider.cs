using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.AI.Actions;
using Windows.AI.Actions.Provider;
using Windows.Foundation;

namespace ExampleAppActionProvider
{
    // AppActionProvider.cs
    [System.Runtime.InteropServices.GuidAttribute("0067C3DD-920A-4486-83C3-9FAD82AFFA7A")]
    public partial class AppActionProvider : IActionProvider {
        public IAsyncAction InvokeAsync(ActionInvocationContext context)
        {
            return InvokeAsyncHelper(context).AsAsyncAction();
        }

        // AppActionProvider.cs
        async Task InvokeAsyncHelper(ActionInvocationContext context)
        {
            NamedActionEntity[] inputs = context.GetInputEntities();

            // Replace this line:
            // var actionId = context.ActionId;
            // With the following line to use ActionName instead:
            var actionId = context.ActionId;
            switch (actionId)
            {
                case "ExampleActionProvider.SendMessage":
                    foreach (NamedActionEntity inputEntity in inputs)
                    {
                        if (inputEntity.Name.Equals("message", StringComparison.Ordinal))
                        {

                            TextActionEntity entity = (TextActionEntity)(inputEntity.Entity);
                            string message = entity.Text;

                            // TODO: Process the message and generate a response

                            string response = "This is the message response";
                            TextActionEntity result = context.EntityFactory.CreateTextEntity(response);
                            context.SetOutputEntity("response", result);

                        }

                    }

                    break;

                default:

                    break;

            }

        }
    }
}
