using System;
using InternalDslTaskManagement.Builder.Interfaces;

namespace InternalDslTaskManagement.Dsl
{
    public class MdsdHomework : TaskManagement
    {
        public MdsdHomework(IServiceProvider serviceProvider, IRootBuilder rootBuilder) : base(serviceProvider,
            rootBuilder)
        {
        }

        public override void Build()
        {
            TaskManagementSystem
                .Task("Read for MDSD").Deadline("09-02-21 08:00").Status("In progress").Assign("Daniel")
                    .Label("Reading").Label("MDSD")
                    .Comment("Completed chapter 4").By("Daniel").PostedAt("07-02-21 14:00")
                    .Comment("Completed chapter 11").By("Daniel").PostedAt("07-02-21 14.40")
                .Task("Post \"Internal DSL mock-up\"").Deadline("09-02-21 08:00").Status("Done").Assign("Daniel")
                    .Label("Individual activity").Label("MDSD")
                    .Comment("Various ideas: ....").By("Daniel").PostedAt("05-02-21 11.30")
                .Task("Assignment 1").Deadline("16-02-2021 08:45").Status("To do").Assign("Daniel")
                    .Label("Assignment").Label("MDSD")
                .Build();
        }
    }
}