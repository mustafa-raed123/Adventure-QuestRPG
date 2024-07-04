using Adventure.Classes;
using static Adventure.Classes.Monster;

namespace AdventTest
{
    public class UnitTest1
    {
        //[Fact]
        //public void PlayerAttack_ReduceMonsterHealth()
        //{
        //    // Arrange
        //    Player players = new Player("Player", 100);
        //    ClsMonster monsters = new ClsMonster("Monster", 100);
        //    int monsterHealthBeforeAttack = monsters.Health;

        //    BattleSystem battleSystem = new BattleSystem();

        //    // Act
        //    battleSystem.Attack(ref players, ref monsters);

        //    int monsterHealthAfterAttack = monsters.Health;

        //    // Assert
        //    Assert.True(monsterHealthAfterAttack < monsterHealthBeforeAttack);
        //}
        //[Fact]
        //public void MonstorAttacker()
        //{
        //    //Act
        //    Player player = new Player("PLayer", 100);
        //    ClsMonster monster = new ClsMonster("Monster", 100);
        //    //Arange
        //    BattleSystem battleSystem = new BattleSystem();
        //    int PlayerHealthBefore = player.Health;
        //    battleSystem.Attack(ref monster, ref player);
        //    int playerHealthAfter = player.Health;
        //    //Assert

        //    Assert.True(PlayerHealthBefore > playerHealthAfter);
        //}
        //[Fact]
        //public void HealthAfterEndBattle()
        //{

        //    //Act
        //    Player player = new Player("PLayer", 100);
        //    ClsMonster monster = new ClsMonster("Monster", 100);
        //    //Arange
        //    BattleSystem battleSystem = new BattleSystem();
        //    battleSystem.Test = true;
        //    battleSystem.StartBattle(player, monster);
        //    int HealthWenner = 0;
        //    HealthWenner = player.Health > monster.Health ? player.Health : monster.Health;
        //    int HealthLoser = 0;
        //    HealthLoser = player.Health < monster.Health ? player.Health : monster.Health;
        //    //Asser
        //    Assert.True(HealthWenner > 0);
        //    Assert.True(HealthLoser == 0);
        //}
    }
}