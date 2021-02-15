using System;
using InternalDslTaskManagement.Builder.Interfaces;

namespace InternalDslTaskManagement.Dsl
{
    public class HousePeace : TaskManagement
    {
        public HousePeace(IServiceProvider serviceProvider, IRootBuilder rootBuilder) : base(serviceProvider,
            rootBuilder)
        {
        }

        public override void Build()
        {
            TaskManagementSystem
                .Task("Prepare lovely dinner").Deadline("09-03-21 18:00").Status("To do").Assign("Daniel")
                .Label("Cooking")
                .Comment("Decided upon meatloaf").By("Daniel").PostedAt("07-03-21 14:21")
                .Comment("Done shopping").By("Daniel").PostedAt("07-02-21 15.42")
                .Task("Do laundry").Deadline("10-03-21 10:00").Status("In progress").Assign("Karoline")
                .Label("Laundry")
                .Comment("Sorted the clothes and started the machine").By("Karoline").PostedAt("10-03-21 08.30")
                .Task("Vacuum clean").Deadline("05-03-2021 12:00").Status("Done").Assign("Daniel")
                .Label("Cleaning")
                .Task("Wash the floors").Deadline("05-03-2021 13:00").Status("Done").Assign("Daniel")
                .Label("Cleaning")
                .Build();
        }
    }
}