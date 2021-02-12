using System;
using InternalDslTaskManagement.Builder.Interfaces;
using InternalDslTaskManagement.Models;
using Microsoft.Extensions.DependencyInjection;

namespace InternalDslTaskManagement.Builder
{
    public class LabelBuilder : FromTaskBuilder, ILabelBuilder
    {
        public LabelBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public string LabelName { get; set; }

        public new ILabelBuilder Label(string name)
        {
            Clear();
            LabelName = name;
            return this;
        }

        public override void Clear()
        {
            if (LabelName == null)
            {
                return;
            }

            Console.WriteLine("LabelBuilder->Clear");
            // Save Label
            var newLabel = new Label(LabelName);
            ServiceProvider.GetRequiredService<ITaskBuilderService>().AddLabel(newLabel);

            LabelName = null;
        }

        public new ITaskBuilder Task(string name)
        {
            Clear();
            return base.Task(name);
        }

        public new ICommentBuilder Comment(string name)
        {
            Clear();
            return base.Comment(name);
        }
    }
}