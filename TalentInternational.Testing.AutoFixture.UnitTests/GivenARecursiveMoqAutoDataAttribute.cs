﻿using System.Collections.Generic;
using AutoFixture.NUnit3;
using Moq;
using NUnit.Framework;

namespace TalentInternational.Testing.AutoFixture.UnitTests
{
    public class GivenARecursiveMoqAutoDataAttribute
    {
        [Test, RecursiveMoqAutoData]
        public void And_Circular_Reference_Then_Injects_Mocked_Interface(
            Entity1 entity1,
            [Frozen] Mock<IDependency> mockDependency,
            Consumer consumer)
        {
            Assert.Pass();
        }
    }

    public class Entity1
    {
        public Entity2 Entity2 { get; set; }
    }

    public class Entity2
    {
        public List<Entity1> Entity1s { get; set; }
    }
}