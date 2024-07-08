using Adventure.Classes;
using static Adventure.Classes.Monster;



namespace AdventTest
{
    public class UnitTest1
    {


        [Fact]
        public void CurrentLocation()
        {
            //Arrange
            Adventures adventures = new Adventures();
            //Act
            string CurrentLocation = adventures.CurrentLocation;  // Forest
            adventures.ChangeCurrrentLocation(2);    //  {Forest = 1 ,Town = 2 ,Caves = 3 ,Mines = 4 ,Demonic Deserts = 5}

             CurrentLocation = adventures.CurrentLocation;  // Town

            //Assert

            Assert.Equal(CurrentLocation, "Town");
        }
        [Fact]
        public void ChoiceMonster_ShouldCreateCorrectBossMonster()
        {
            // Arrange
            var adventures = new Adventures();
            var expectedBossName = "Dragon";
            var expectedBossHealth = 22 * (4 + 9); 
            var expectedBossAttackPower = (4 + 2) * 4; 

            // Act
            adventures.ChoiceMonster();

            // Assert
            var bossMonster = adventures.lsMonstoer[4] as BossMonster;
            Assert.NotNull(bossMonster);
            Assert.Equal(expectedBossName, bossMonster.Name);
            Assert.Equal(expectedBossHealth, bossMonster.Health);
            Assert.Equal(expectedBossAttackPower, bossMonster.AttackPower);
        }

    }
}