using AutoMapper; 
using Moq; 
using TransporSystems.Frontend.Utils.Mapping; 
using Xunit; 
 
namespace TransportSystems.Frontend.Utils.UnitTests 
{ 
    public class MappingServiceTestsSuite 
    { 
        public MappingServiceTestsSuite() 
        { 
            Mapper = new Mock<IMapper>(); 
            MappingService = new MappingService(Mapper.Object); 
        } 
 
        public Mock<IMapper> Mapper { get; } 
 
        public IMappingService MappingService { get; } 
 
        public class TestDTO 
        { 
        } 
 
        public class Test 
        { 
        } 
    } 
 
    public class MappingServiceTests 
    {
        public MappingServiceTests() 
        { 
            Suite = new MappingServiceTestsSuite(); 
        } 
 
        protected MappingServiceTestsSuite Suite { get; } 
 
        [Fact] 
        public void MapWithGeneric() 
        {
            var dto = new MappingServiceTestsSuite.TestDTO(); 
             var dest = new MappingServiceTestsSuite.Test();

            Suite.Mapper
                  .Setup(m => m.Map<MappingServiceTestsSuite.Test>(dto))
                  .Returns(dest);

            var result = Suite.MappingService.Map<MappingServiceTestsSuite.Test>(dto); 
 
            Suite.Mapper.Verify(m => m.Map<MappingServiceTestsSuite.Test>(dto)); 
            Assert.Equal(dest, result);
        }

        [Fact]
        public void MapWithTwoGenericTypes()
        {
            var dto = new MappingServiceTestsSuite.TestDTO(); 
             var dest = new MappingServiceTestsSuite.Test();

            Suite.Mapper
                  .Setup(m => m.Map<MappingServiceTestsSuite.TestDTO, MappingServiceTestsSuite.Test>(dto))
                  .Returns(dest);

            var result = Suite.MappingService.Map<MappingServiceTestsSuite.TestDTO, MappingServiceTestsSuite.Test>(dto); 
 
            Suite.Mapper.Verify(m => m.Map<MappingServiceTestsSuite.TestDTO, MappingServiceTestsSuite.Test>(dto)); 
            Assert.Equal(dest, result);
        }
 
        [Fact] 
        public void MapWithExistObject() 
        { 
            var dto = new MappingServiceTestsSuite.TestDTO(); 
            var dest = new MappingServiceTestsSuite.Test(); 
            Suite.MappingService.Map(dto, dest); 
 
            Suite.Mapper.Verify(m => m.Map(dto, dest)); 
        } 
    } 
}