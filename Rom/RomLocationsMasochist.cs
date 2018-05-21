//nothing hidden, items are hidden the way they should be
//no limitations
//                                   NoHidden = true,
//                                   ItemStorageType = ItemStorageType.Hidden, {chozo,hidden, blank}


using System;
using System.Collections.Generic;
using System.Linq;
using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomLocationsMasochist : IRomLocations
    {
        public List<Location> Locations { get; set; }
        public string DifficultyName { get { return "Masochist"; } }
        public string SeedFileString { get { return "M{0:0000000}"; } }
        public string SeedRomString { get { return "SMRv{0} M{1}"; } }

        public void ResetLocations()
        {
           Locations = new List<Location>
                       {
           	//define difficulty: casual
           	//all 100 items
           	//walljumping should be the minimum requirement for player skill 
           	//space jump is ok, speedbooster may be difficult for newer players
           	//no hellruns and no suitless maridia, small suitless for WS
           	//ice beam may be used to get to higher areas
           	//ibj not required
           	//charge beam and plasma beam are outside of difficult areas like LN
           	
           	//define difficulty: veteran
           	//all 100 items
           	//many advanced tricks may be required from project base runners such as shinespark, backflip, etc
           	//suitless hellruns and gravity hellruns will be possible which will required extra fine tuning for both possibilities
           	//suitless maridia will be possible as far as it goes
           	//however suitless will not be forced into LN
           	//more ibj will be used, but not in a masochistic way
           	
           	//generally suitless will be possible
           	//advanced techniques are used
           	//more variety
					    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Backflip Tutorial",
                                   Address = 0x79060,
                                   //index = 01,
                                   CanAccess =
                                       have =>
                                   	true,
                                   //can enforce morphball or high jump
                                   //can be accessed with just walljumps
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Spazer Beam",
                                   Address = 0x78B14,
                                   CanAccess =
                                       have =>
									// CanIBJ(have)
									(CanEnterPassages(have)
                                   	 && have.Contains(ItemType.SpaceJump))
                                   	|| CanSpringBallJump(have),
									// || have.Contains(ItemType.SpeedBooster)),
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Crateria Cliff - Power Bombs",
                                   Address = 0x78124,
                                   CanAccess =
                                       have =>
                                   	have.Contains(ItemType.SpaceJump)
									&& have.Contains(ItemType.SpeedBooster),
                               },
                            new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Wave Beam",
                                   Address = 0x7903A,
                                   CanAccess =
                                       have =>
									// CanIBJ(have)
									// || CanSpringBallJump(have)
									// || 
                                   	//(CanOpenMissileDoors(have)
                                   	 //|| have.Contains(ItemType.MorphingBall))
									have.Contains(ItemType.HiJumpBoots)
                                   	 || have.Contains(ItemType.SpaceJump)
									 || have.Contains(ItemType.IceBeam),
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Wave Beam Missiles",
                                   Address = 0x79046,
                                   CanAccess =
                                       have =>
                                   	// (CanOpenMissileDoors(have)
                                   	// || have.Contains(ItemType.MorphingBall))
									 CanEnterPassages(have),
                                   // CanSpeedBall(have)   
									// ||
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   //Name = "Early Missiles",
                                   Name = "WallJump Missiles",
                                   Address = 0x7904C,
                                   //index = 0c,
                                   CanAccess =
                                       have =>
									true,
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Morphing Ball",
                                   //index = 0E, 
                                   Address = 0x7816A,
                                   CanAccess =
                                       have =>
									true,
                               },
                          new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Crateria E-Tank",
                                   Address = 0x78178,
                                   CanAccess =
                                       have =>
									// have.Contains(ItemType.MorphingBall)
									CanOpenMissileDoors(have),
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Pipe Missiles",
                                   Address = 0x78212,
                                   CanAccess =
                                       have =>
									CanOpenMissileDoors(have),
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Tunnel Missiles",
                                   Address = 0x7907C,
                                   CanAccess =
                                       have =>
									// CanIBJ(have)
									// ||
                                   	CanOpenMissileDoors(have)
									&& CanOpenPassages(have)
									&& CanSpringBallJump(have),
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Sidehopper Lake",
                                   Address = 0x78290,
                                   CanAccess =
                                       have =>
									CanUsePowerBombs(have)
									// && (CanSpringBallJump(have)
									// || CanIBJ(have))
									
									&& (have.Contains(ItemType.GravitySuit)
                                   	    || have.Contains(ItemType.HiJumpBoots)),
									// Check again for escape possibilities
									// level has been changed slightly to accomdate for 2 escape options
										// 1 - suitless with high jump boots + walljump
										// 2 - gravity without highjump boots + walljump
											// and other variations with gravity suit
									// morph ball locks have been removed to avoid both ibj and/or springball
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Crateria Ship - Reserve Tank",
                                   //Address = 0x782C5,
                                   Address = 0x782C4,
                                   CanAccess =
                                       have =>
									CanSpeedBall(have),
                               },
                            new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "X-Ray",
                                   Address = 0x7C737,
                                   CanAccess =
                                       have =>
									CanOpenMissileDoors(have)
									//&& CanEnterPassages(have),
                                   	&& have.Contains(ItemType.MorphingBall),
                                   //adjusted map for morph+shot/bomb block
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Intended First Missiles",
                                   Address = 0x78A98,
                                   CanAccess =
                                       have =>
                                   	true,
									//CanOpenMissileDoors(have),
									// have.Contains(ItemType.MorphingBall),
                                   	// nothing is required with morph ball level edits
                                   // in a harder difficulty, can go from backflip tutorial -> intended first missiles
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Early Supers",
                                   Address = 0x78188,
                                   CanAccess =
                                       have =>
									// CanIBJ(have)
									// || CanSpringBallJump(have)
									// || have.Contains(ItemType.ScrewAttack)
									
									// || 
                                   	have.Contains(ItemType.MorphingBall)
                                   	&& (have.Contains(ItemType.SpaceJump))
                                   	   // || have.Contains(ItemType.SpeedBooster)),
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   //Name = "Final Missiles",
                                   Name = "Wall Chozo",
                                   Address = 0x78D66,
                                   CanAccess =
                                       have =>
									CanEnterPassages(have),
                               },
							    new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Wrecked Ship Entrance Missiles",
                                   Address = 0x78236,
								   // Check for correct address
                                   CanAccess =
                                       have =>
									// CanIBJ(have)
									// || 
									have.Contains(ItemType.HiJumpBoots)
                                   	|| have.Contains(ItemType.SpaceJump),
                               },
							    // 17 Crateria items
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "Spike Tunnel",
                                   Address = 0x78968,
                                   CanAccess =
                                       have =>
									CanEnterWS(have)
									// limit for what it takes to defeat phantoon
									&& have.Contains(ItemType.GrappleBeam),
                               },
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "Green Tower Supers",
                                   Address = 0x789A4,
                                   CanAccess =
                                       have =>
									CanEnterInnerWS(have),
                               },
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "WS Reserves",
                                   Address = 0x789BC,
                                   CanAccess =
                                       have =>
									CanEnterInnerWS(have)
									&& CanUsePowerBombs(have),
                               },
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "Conveyor Belt Robots",
                                   Address = 0x789FC,
                                   CanAccess =
                                       have =>
									CanEnterWS(have)
									&& have.Contains(ItemType.SuperMissile),
                               },
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   // Name = "Dead Spike Missile",
                                   Name = "WS Middle",
                                   Address = 0x78A02,
                                   CanAccess =
                                       have =>
									CanEnterWS(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "Phantoon E-Tank",
                                   Address = 0x78A0E,
                                   CanAccess =
                                       have =>
									CanEnterWS(have)
									&& have.Contains(ItemType.GrappleBeam),
                               },
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "WS Attic - Varia Suit",
                                   Address = 0x78A22,
                                   CanAccess =
                                       have =>
									CanEnterWS(have)
                                   	
									&& ((have.Contains(ItemType.GrappleBeam)
                                   	     && have.Contains(ItemType.HiJumpBoots))
                                   	     || have.Contains(ItemType.SpaceJump))
                                   	     
									|| (have.Contains(ItemType.SuperMissile)
                                   	         && CanIBJ(have)
                                   	  && ((have.Contains(ItemType.GrappleBeam)
                                   	     && have.Contains(ItemType.HiJumpBoots))
                                   	     || have.Contains(ItemType.SpaceJump))),
                                   //ibj shouldn't be too difficult for most people
                               },
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "Bowling Chozo",
                                   Address = 0x78A84,
                                   CanAccess =
                                       have =>
									CanEnterWS(have)
                                   	//limit for phantoon
                                   	&& have.Contains(ItemType.GrappleBeam)
									&& CanUsePowerBombs(have),
                               },
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "Upper WS E-Tank",
                                   Address = 0x78AE8,
                                   CanAccess =
                                       have =>
									CanEnterInnerWS(have)
									&& have.Contains(ItemType.GravitySuit)
									&& (have.Contains(ItemType.SpeedBooster)
									|| have.Contains(ItemType.SpaceJump)),
                               },
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "Moss Maze",
                                   //Address = 0x78B5E,
                                   Address = 0x78AFA,
								   // check address
                                   CanAccess =
                                       have =>
									(CanEnterInnerWS(have)
                                   	 && CanUsePowerBombs(have))
									
									&& (((have.Contains(ItemType.GravitySuit)
                                   	     && CanIBJ(have))
									
									|| (have.Contains(ItemType.HiJumpBoots)
                                   	         && have.Contains(ItemType.SpringBall)))),
                               },
                          new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "Outer Maze",
                                   //Address = 0x78AFA,
                                   Address = 0x78B00,
								   // check address
                                   CanAccess =
                                       have =>
									(CanEnterInnerWS(have)
                                   	 && CanUsePowerBombs(have))
									
									&& (((have.Contains(ItemType.GravitySuit)
                                   	     && CanIBJ(have))
									
									|| (have.Contains(ItemType.HiJumpBoots)
                                   	         && have.Contains(ItemType.SpringBall)))),
                               },
                          // 11 WS Items
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Bomb Torizo",
                                   Address = 0x78256,
                                   CanAccess =
                                       have =>
									have.Contains(ItemType.MorphingBall)
									&& CanOpenMissileDoors(have),
                               },			
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.UpperBrinstar,
                                   Name = "Kraid Supers",
                                   Address = 0x78C80,
                                   CanAccess =
                                       have =>
									CanAccessUpperBrinstar(have)
                                   	//ice beam used to reach alternative path to kraid
									&& (have.Contains(ItemType.IceBeam)
									|| have.Contains(ItemType.HiJumpBoots)),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Hi Jump Boots",
                                   Address = 0x782E6,
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have)
									|| AccessFrogPath(have),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Caterpillar Missiles",
                                   Address = 0x784F4,
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have),
                               },
                            new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.UpperBrinstar,
                                   Name = "Dachora Missiles",
                                   Address = 0x78138,
                                   CanAccess =
                                       have =>
									CanAccessUpperBrinstar(have)
									&& (have.Contains(ItemType.GravitySuit)
									|| have.Contains(ItemType.HiJumpBoots))
									
									&& (CanEnterPassages(have)
									|| have.Contains(ItemType.WaveBeam))
									
									&& (have.Contains(ItemType.IceBeam)
									|| have.Contains(ItemType.HiJumpBoots)),
                                   
                                   // should recheck for more sound logic
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.UpperBrinstar,
                                   Name = "Upper Brinstar E-Tank",
                                   Address = 0x78322,
                                   CanAccess =
                                       have =>
									CanAccessUpperBrinstar(have)
									
									&& (CanUsePowerBombs(have)
                                   	    //grapple beam limit for kago lake
									|| have.Contains(ItemType.GrappleBeam)),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Bomb Tower Middle",
                                   Address = 0x7EBB8,
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have),
                               },
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Bomb Tower Right",
                                   Address = 0x7EBC4,
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have)
									&& CanEnterPassages(have),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Blue Grapple Tower Missile",
                                   Address = 0x783EC,
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have),
									
									// || (have.Contains(ItemType.SuperMissile)
									// || have.Contains(ItemType.ChargeBeam))),
                                   
                                   // no longer accomodates for charge room's 4 enemy count grey doors
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.UpperBrinstar,
                                   Name = "Grate Power Bombs",
                                   Address = 0x783FC,
                                   CanAccess =
                                       have =>
									CanAccessUpperBrinstar(have)
									&& CanUsePowerBombs(have),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "SporeSpawn Missiles",
                                   Address = 0x78414,
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have)
									&& have.Contains(ItemType.SpaceJump)
									// CanIBJ(have),
									// limit
									&& have.Contains(ItemType.GrappleBeam),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.UpperBrinstar,
                                   Name = "Kago Lake Supers",
                                   Address = 0x78428,
                                   CanAccess =
                                       have =>
									CanAccessUpperBrinstar(have)
									&& have.Contains(ItemType.GravitySuit),
                                   //obtainable using space jump, semi precise
                               },	
							   new Location
                               { 
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.UpperBrinstar,
                                   Name = "SporeSpawn E-Tank",
                                   Address = 0x7844C,
                                   //recheck address
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have)
									&& have.Contains(ItemType.SpaceJump)
									// CanIBJ(have),
									// limit
									&& have.Contains(ItemType.GrappleBeam),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Blue Ripper Tower",
                                   Address = 0x78468,
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have)
									&& have.Contains(ItemType.SuperMissile),
                               },	
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Red Grapple Tower",
                                   Address = 0x78470,
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have)
									// limit for new players
									&& have.Contains(ItemType.GrappleBeam),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.UpperBrinstar,
                                   Name = "Brinstar Reserves",
                                   Address = 0x78478,
                                   CanAccess =
                                       have =>
									CanAccessUpperBrinstar(have)
									&& CanUsePowerBombs(have),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.UpperBrinstar,
                                   Name = "Mini-Kraid ETank",
                                   //Address = 0x78478,
                                   Address = 0x784BE,
                                   CanAccess =
                                       have =>
									CanAccessUpperBrinstar(have)
									&& CanUsePowerBombs(have)
									&& have.Contains(ItemType.SpeedBooster),
									// sidehoppers can be defeated with missiles
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Grapple Beam",
                                   Address = 0x79722,
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Grapple Missiles / Crossroads",
                                   Address = 0x784FC,
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have)
									
									&& (have.Contains(ItemType.SuperMissile)
									|| have.Contains(ItemType.ChargeBeam)),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.UpperBrinstar,
                                   Name = "Space Jump",
                                   Address = 0x78546,
                                   CanAccess =
                                       have =>
									CanAccessUpperBrinstar(have)
									&& (have.Contains(ItemType.IceBeam)
									|| have.Contains(ItemType.HiJumpBoots)),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Frog E-Tank",
                                   Address = 0x78ABC,
                                   CanAccess =
                                       have =>
									have.Contains(ItemType.HiJumpBoots)
                                   	|| have.Contains(ItemType.SpaceJump),
									// || CanIBJ(have),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Chozo Lake Missiles",
                                   Address = 0x7E984,
                                   CanAccess =
                                       have =>
									AccessFrogPath(have)
									
									&& (have.Contains(ItemType.GrappleBeam)
									|| have.Contains(ItemType.SpaceJump)),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Charge Beam",
                                   //Address = 0x78312, //this might be part of an unknown room state
                                   //could cause problems later
                                   //Address = 0x78438,
                                   Address = 0x78312,
                                   // both items should be randomized now via patch
                                   CanAccess =
                                       have =>
									CanEnterBrinstarMiddle(have)
									// limit
									&& (have.Contains(ItemType.GrappleBeam)
									|| have.Contains(ItemType.SpaceJump)
									|| have.Contains(ItemType.SpeedBooster)),
									
									// room has been adjusted for grey doors to open upon 2 kills.
                               },	
							   // 23 brinstar items
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Ice Beam",
                                   //Address = 0x785DC,
                                   Address = 0x785FA,
                                   CanAccess =
                                       have =>
									CanAccessNorfair(have),
                               },			
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Ice E-Tank",
                                   Address = 0x78572,
                                   CanAccess =
                                       have =>
                                   	CanSpringBallJump(have)
									   //or mockball
                                   	&& CanAccessNorfair(have)
                                   	
									&& (have.Contains(ItemType.GrappleBeam)
									|| have.Contains(ItemType.SpaceJump)),
									// 3 routes
									//&& (CanAccessIceBeamPath(have)
                                   	//    || CanAccessNorfair(have)),
									// || CanEnterRightNorfair(have)),
									// removal for not being necessary
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Missile Tower - Middle",
                                   Address = 0x7857A,
                                   CanAccess =
                                       have =>
                                   	CanAccessNorfair(have)
                                   	&& have.Contains(ItemType.MorphingBall),
                                   	
									// (CanAccessIceBeamPath(have)
                                   	// || CanAccessNorfair(have)),
									// || CanEnterRightNorfair(have)),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Missile Tower - Lower",
                                   Address = 0x78582,
                                   CanAccess =
                                       have =>
                                   	CanAccessNorfair(have),
									// (CanAccessIceBeamPath(have)
									// || CanAccessNorfair(have)),
									// || CanEnterRightNorfair(have)),
                               },	
							   new Location
                               { 
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Missile Tower - Ridley Statue",
                                   Address = 0x78FA8,
                                   CanAccess =
                                       have =>
                                   	CanAccessNorfair(have)
									&& have.Count(x => x == ItemType.EnergyTank) >= 2,
									// (CanAccessIceBeamPath(have)
									// || CanAccessNorfair(have)),
									// || CanEnterRightNorfair(have)),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Teaser Supers",
                                   Address = 0x785D0,
                                   CanAccess =
                                       have =>
									CanAccessNorfair(have)
                                   	&& have.Contains(ItemType.MorphingBall)
									&& have.Contains(ItemType.SuperMissile)
									// && CanIBJ(have)
									&& have.Contains(ItemType.SpaceJump),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Teaser Missiles",
                                   Address = 0x785DC,
                                   CanAccess =
                                       have =>
									CanAccessMiddleNorfair(have),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Crocomire - Missiles",
                                   Address = 0x78766,
                                   CanAccess =
                                       have =>
									CanAccessNorfair(have)
                                   	&& have.Contains(ItemType.MorphingBall)
									&& have.Contains(ItemType.SuperMissile),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Spring Ball",
                                   Address = 0x7910C,
                                   CanAccess =
                                       have =>
									CanAccessNorfair(have)
                                   	&& have.Contains(ItemType.MorphingBall)
									&& have.Contains(ItemType.SuperMissile)
									// && CanIBJ(have)
									&& have.Contains(ItemType.SpaceJump),
                                   	
									   //2 routes - Crocomire (Mid Norfair) or Maridia Tube
									// (CanAccessMiddleNorfair(have)
									// && have.Contains(ItemType.SpaceJump))
									// || CanAccessMaridiaTube(have),
									
									//newer players could really get stuck
									//might enforce high jump, some spots are barely doable
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Boulder Hallway Missiles",
                                   Address = 0x787D0,
                                   CanAccess =
                                       have =>
									CanAccessNorfair(have)
                                   	&& have.Contains(ItemType.MorphingBall)
									&& have.Contains(ItemType.SuperMissile),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Norfair Reserves",
                                   Address = 0x78650,
                                   CanAccess =
                                       have =>
									CanAccessMiddleNorfair(have)
									&& have.Contains(ItemType.GravitySuit)
									&& have.Count(x => x == ItemType.EnergyTank) >= 7
									&& CanUsePowerBombs(have),
									//400 health with spring ball
									//600 health with ibj
									//if varia only = ded
									//removed morph locks
                               },	
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Norfair Reserves - Speed Valley",
                                   Address = 0x7867A,
                                   CanAccess =
                                       have =>
									CanAccessMiddleNorfair(have)
									&& have.Contains(ItemType.SpeedBooster),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Mining Quarry - Intended Supers",
                                   Address = 0x7872E,
                                   CanAccess =
                                       have =>
									(CanAccessNorfair(have)
                                   	&& CanEnterPassages(have)
                                   	&& have.Contains(ItemType.SuperMissile))
                                   	
                                   	|| (CanAccessMiddleNorfair(have)
                                   	&& CanEnterPassages(have)),
                                   //could force super missiles for this or have not respawning crumbles
                                   
									   //2 routes - Crocomire (Mid Norfair) or Maridia Tube
									// CanAccessMiddleNorfair(have)
									// || CanAccessMaridiaTube(have),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Mining Quarry - Missiles",
                                   Address = 0x79299,
                                   CanAccess =
                                       have =>
									(CanAccessNorfair(have)
                                   	 && CanSpringBallJump(have)
                                   	&& CanEnterPassages(have)
                                   	&& have.Contains(ItemType.SuperMissile))
                                   	
                                   	|| (CanAccessMiddleNorfair(have)
                                   	    && CanSpringBallJump(have)
                                   	&& CanEnterPassages(have)),
                                   
									   //2 routes - Crocomire (Mid Norfair) or Maridia Tube
								//	   CanSpringBallJump(have)
								//	&& (CanAccessMiddleNorfair(have)
									// || CanAccessMaridiaTube(have)),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Metroid Chozo",
                                   Address = 0x786FA,
                                   CanAccess =
                                       have =>
                                   	CanAccessMiddleNorfair(have)
									&& CanUsePowerBombs(have)
									   //2 routes - Crocomire (Mid Norfair) or Maridia Tube
									
									// && (CanAccessMiddleNorfair(have)
									// || CanAccessMaridiaTube(have)),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Lava Dive E-Tank",
                                   Address = 0x78714,
                                   CanAccess =
                                       have =>
									CanAccessNorfair(have),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Boulder Supers",
                                   Address = 0x78742,
                                   CanAccess =
                                       have =>
									CanAccessNorfair(have)
                                   	//&& CanEnterPassages(have)
                                   	&& have.Contains(ItemType.MorphingBall)
									&& have.Contains(ItemType.SuperMissile),
									   //2 routes - Crocomire (Mid Norfair) or Maridia Tube
								//	CanAccessMiddleNorfair(have)
								//	|| CanAccessMaridiaTube(have),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Acid Lake - Cliff Missiles",
                                   Address = 0x7C3FC,
                                   CanAccess =
                                       have =>
									CanAccessMiddleNorfair(have)
                                   	&& have.Contains(ItemType.SuperMissile)
                                   	// grapple for casual
                                   	&& have.Contains(ItemType.GrappleBeam)
									&& (have.Contains(ItemType.SpaceJump)
									 || have.Contains(ItemType.SpeedBooster)),
                                   //difficult to obtain with only ice beam
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Lava Maze - Cliff Supers",
                                   Address = 0x7862E,
                                   CanAccess =
                                       have =>
									CanAccessMiddleNorfair(have)
                                   	&& have.Contains(ItemType.GrappleBeam)
                                   	&& have.Contains(ItemType.SuperMissile)
									// && CanIBJ(have)
									&& (have.Contains(ItemType.SpaceJump)
									|| have.Contains(ItemType.SpeedBooster)),
                               },	
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "GT Supers",
                                   Address = 0x790F8,
                                   CanAccess =
                                       have =>
									CanAccessMiddleNorfair(have)
                                   	&& CanFightCrocomire(have)
                                   	//enter from grey-crocomire door
                                   	&& CanUsePowerBombs(have)
									&& have.Contains(ItemType.SuperMissile),
									// CanAccessMiddleNorfair(have)
									// && CanUsePowerBombs(have),
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.LowerNorfair,
                                   Name = "LN Elevator - Left Missile",
                                   Address = 0x7878A,
                                   CanAccess =
                                       have =>
									CanAccessLN(have)
									&& have.Contains(ItemType.SpeedBooster),
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.LowerNorfair,
                                   Name = "SpeedBooster",
                                   Address = 0x787D8,
                                   CanAccess =
                                       have =>
									CanAccessLN(have)
									&& CanEnterPassages(have),
									//fixed room to prevent softlocks
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.LowerNorfair,
                                   Name = "LN Speed Challenge - Power Bombs",
                                   Address = 0x7880E,
                                   CanAccess =
                                       have =>
									CanAccessLN(have)
									&& CanUsePowerBombs(have)
									&& have.Contains(ItemType.SpeedBooster),
                               },		
                            new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.LowerNorfair,
                                   Name = "LN Elevator - E-Tank",
                                   Address = 0x78844,
                                   CanAccess =
                                       have =>
									CanAccessLN(have)
									&& CanUsePowerBombs(have)
									&& (have.Contains(ItemType.SpeedBooster)
									|| have.Contains(ItemType.SpaceJump)),
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.LowerNorfair,
                                   Name = "LN Elevator - Right Missiles",
                                   Address = 0x78850,
                                   CanAccess =
                                       have =>
									CanAccessLN(have)
									&& have.Contains(ItemType.SpeedBooster)
									&& CanEnterPassages(have),
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.LowerNorfair,
                                   Name = "LN Warehouse",
                                   Address = 0x78886,
                                   CanAccess =
                                       have =>
									CanAccessLN(have)
									&& CanUsePowerBombs(have),
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.LowerNorfair,
                                   Name = "Ridley Supers",
                                   Address = 0x78894,
                                   CanAccess =
                                       have =>
									CanAccessLN(have)
									&& CanUsePowerBombs(have),
									//ice beam + backflip crumbles, hj is also possible
                               },				
							   // 27 norfair+LN items
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "Gravity Suit",
                                   Address = 0x786D0,
                                   CanAccess =
                                       have =>
									(CanEnterMaridia(have)
                                   	&& have.Contains(ItemType.Missile))
                                   	//&& (have.Contains(ItemType.HiJumpBoots))
									// || have.Contains(ItemType.GravitySuit))
									
                                   	&& (CanSpringBallJump(have)
									&& have.Contains(ItemType.IceBeam)),
                               },			
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "SandFall Missiles",
                                   Address = 0x788AC,
                                   CanAccess =
                                       have =>
									(CanEnterMaridia(have)
									|| BackdoorMaridia(have))
									
									// && have.Contains(ItemType.GravitySuit)
									&& (have.Contains(ItemType.HiJumpBoots)
									|| have.Contains(ItemType.SpaceJump)
									|| have.Contains(ItemType.SpeedBooster)),
                               },			
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "Maridia Ruins - Left Missile",
                                   Address = 0x785BC,
                                   CanAccess =
                                       have =>
									CanEnterMaridia(have)
									&& have.Contains(ItemType.HiJumpBoots),
									// || have.Contains(ItemType.GravitySuit)
									// for hj-less gravity jump
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "Maridia Ruins - Right Missile",
                                   Address = 0x785C2,
                                   // check address for accuracy
                                   CanAccess =
                                       have =>
									CanEnterInnerWS(have),
									// || have.Contains(ItemType.GravitySuit)
									// for hj-less gravity jump
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "12th Street - Missiles",
                                   Address = 0x78828,
                                   CanAccess =
                                       have =>
									(CanEnterMaridia(have)
									|| BackdoorMaridia(have))
									
									&& (have.Contains(ItemType.GravitySuit)
									&& have.Contains(ItemType.SpeedBooster)),
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "13th Street - Supers",
                                   Address = 0x78954,
                                   CanAccess =
                                       have =>
									CanEnterThirteenthStreet(have)
									&& have.Contains(ItemType.SuperMissile),
									// && have.Contains(ItemType.SpringBall),
									// removed morph lock
                               },			   		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "Plasma Beam",
                                   Address = 0x78CD0,
                                   CanAccess =
                                       have =>
									CanEnterThirteenthStreet(have)
									&& CanUsePowerBombs(have),
									// high damage enemies
                               },					
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "Coral Speedway",
                                   Address = 0x78BAC,
                                   CanAccess =
                                       have =>
									CanEnterThirteenthStreet(have)
									&& (have.Contains(ItemType.GravitySuit)
									&& have.Contains(ItemType.SpeedBooster)),
                               },					
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "Draygon's Chozo Hoard",
                                   Address = 0x78C0C,
                                   CanAccess =
                                       have =>
									CanEnterThirteenthStreet(have)
									&& have.Contains(ItemType.PlasmaBeam)
									&& have.Contains(ItemType.ChargeBeam)
									&& (have.Contains(ItemType.GravitySuit)
									&& have.Contains(ItemType.SpeedBooster)),
                               },					
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "Sandfall Maze - Supers",
                                   Address = 0x78C9A,
                                   CanAccess =
                                       have =>
									CanEnterThirteenthStreet(have)
									&& CanUsePowerBombs(have)
									&& (have.Contains(ItemType.GravitySuit)
									&& have.Contains(ItemType.SpeedBooster)),
                               },					
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "Plasma Power Bombs",
                                   //Address = 0x7C79F,
                                   Address = 0x78BBE,
                                   CanAccess =
                                       have =>
									CanEnterThirteenthStreet(have)
									&& CanUsePowerBombs(have)
									&& (have.Contains(ItemType.GravitySuit)
									&& have.Contains(ItemType.SpeedBooster)),
                               },				
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "Botwoon Power Bombs",
                                   Address = 0x78BD4,
                                   CanAccess =
                                       have =>
									MaridiaRuins(have)
									&& CanOpenMissileDoors(have),
									// can softlock if no pbs
                               },		
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "Botwoon Cove - Missiles",
                                   Address = 0x78BDC,
                                   CanAccess =
                                       have =>
									MaridiaRuins(have),
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Maridia,
                                   Name = "Botwoon Bridge",
                                   Address = 0x78BF8,
                                   CanAccess =
                                       have =>
									MaridiaRuins(have)
									&& CanSpringBallJump(have)
									&& CanUsePowerBombs(have)
									&& (have.Contains(ItemType.SpaceJump)),
                               },			
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.MaridiaDepths,
                                   Name = "Maridia Depths Elevator - Power Bombs",
                                   Address = 0x78C66,
                                   CanAccess =
                                       have =>
									CanEnterMaridiaDepths(have)
									&& CanUsePowerBombs(have),
                               },			
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.MaridiaDepths,
                                   Name = "Pirate/Sandpit E-Tank",
                                   Address = 0x78B9E,
                                   CanAccess =
                                       have =>
									CanEnterMaridiaDepths(have)
									&& CanOpenMissileDoors(have)
									&& CanEnterPassages(have),
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.MaridiaDepths,
                                   Name = "Turtle Reserves",
                                   Address = 0x782FC,
                                   CanAccess =
                                       have =>
									CanEnterMaridiaDepths(have)
									&& have.Contains(ItemType.GravitySuit)
                                   	&& CanSpringBallJump(have)
									// masochistic ibj instead of springball
									&& have.Count(x => x == ItemType.EnergyTank) >= 5,
                                   //springball/varia is highly recommended to reduce damage taken
                               },		
                          new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.MaridiaDepths,
                                   Name = "Shaktool Simulator",
                                   Address = 0x79084,
                                   CanAccess =
                                       have =>
									CanEnterMaridiaDepths(have)
									&& have.Contains(ItemType.SuperMissile)
									&& CanIBJ(have),
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.MaridiaDepths,
                                   Name = "Maridia Tube E-Tank",
                                   Address = 0x78B5E,
                                   CanAccess =
                                       have =>
									CanEnterMaridiaDepths(have)
									&& have.Contains(ItemType.SuperMissile)
									&& CanUsePowerBombs(have),
                               },		
							   new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.MaridiaDepths,
                                   Name = "Maridia Tube - Missiles",
                                   Address = 0x782A0,
                                   CanAccess =
                                       have =>
									CanEnterMaridiaDepths(have)
									&& have.Contains(ItemType.SuperMissile),
                               },		
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.MaridiaDepths,
                                   Name = "Spike-Sand Valley",
                                   Address = 0x78CA8,
                                   CanAccess =
                                       have =>
									CanEnterMaridiaDepths(have)
									&& have.Contains(ItemType.GravitySuit)
									&& (have.Contains(ItemType.SpaceJump)
									|| have.Contains(ItemType.HiJumpBoots)),
                               },	
						// 21 items in Maridia                           
                         new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Screw Attack",
                                   //Address = 0x78F92,
                                   //standard event Screw Attack
                                   Address = 0x78F9A,
                                   //event1 after baby metroid Screw Attack
                                   CanAccess =
                                       have =>
                                   	CanEnterMaridiaDepths(have)
                                   	&& CanAccessLN(have)
                                   	&& CanAccessUpperBrinstar(have)
                                   	&& have.Contains(ItemType.IceBeam),
                                   //not locking out ice beam for casuals
                               },	
                       };
        }
          private static bool CanIBJ(List<ItemType> have)
        {

			return have.Contains(ItemType.MorphingBall)
				&& have.Contains(ItemType.Bomb);
		} 
 private static bool CanOpenPassages(List<ItemType> have)
        {

			return (have.Contains(ItemType.MorphingBall)
				&& have.Contains(ItemType.Bomb))
				|| CanUsePowerBombs(have)
				|| have.Contains(ItemType.ScrewAttack);
		}

 private static bool CanSpringBallJump(List<ItemType> have)
        {

			return have.Contains(ItemType.MorphingBall)
				&& have.Contains(ItemType.SpringBall);
		} 	
 private static bool CanSpeedBall(List<ItemType> have)
        {

			return have.Contains(ItemType.MorphingBall)
				&& have.Contains(ItemType.SpringBall)
				&& have.Contains(ItemType.SpeedBooster);
		} 				
 private static bool CanEnterPassages(List<ItemType> have)
        {

			return (have.Contains(ItemType.MorphingBall)
				&& have.Contains(ItemType.Bomb))
 		|| CanUsePowerBombs(have);
		} 		
private static bool CanOpenMissileDoors(List<ItemType> have)
        {

			return have.Contains(ItemType.Missile)
				|| have.Contains(ItemType.SuperMissile);
		} 	
 private static bool CanUsePowerBombs(List<ItemType> have)
        {

			return have.Contains(ItemType.MorphingBall)
				&& have.Contains(ItemType.PowerBomb)
				&& (have.Count(x => x == ItemType.Missile) >= 1
				    || have.Count(x => x == ItemType.SuperMissile) >= 1);
		} 	

private static bool CanEnterWS(List<ItemType> have)
        {

			return have.Contains(ItemType.MorphingBall)
				// && (CanIBJ(have)
				// || have.Contains(ItemType.ScrewAttack)
				// || 
				&& (have.Contains(ItemType.HiJumpBoots)
				|| have.Contains(ItemType.SpaceJump));
				// || have.Contains(ItemType.SpeedBooster));
				// || have.Contains(ItemType.GravitySuit)
				// gravity could make it too easy...
		} 	
 private static bool CanEnterInnerWS(List<ItemType> have)
        {

			return CanEnterWS(have)
				//casual charge beam limit
				&& have.Contains(ItemType.ChargeBeam)
			&& have.Contains(ItemType.SuperMissile)
				&& have.Contains(ItemType.GravitySuit);
			// || CanIBJ(have))
		} 			
		
 private static bool CanEnterBrinstarMiddle(List<ItemType> have)
        {

			return have.Contains(ItemType.MorphingBall)
			&& CanOpenMissileDoors(have)
				&& CanEnterPassages(have);
			// || have.Contains(SpeedBooster))
		} 				
 private static bool CanAccessUpperBrinstar(List<ItemType> have)
        {

			return CanEnterBrinstarMiddle(have)
				&& have.Contains(ItemType.SuperMissile)
				&& BossArea(have);
		} 					
 private static bool AccessFrogPath(List<ItemType> have)
        {

			return CanEnterPassages(have)
				&& have.Contains(ItemType.HiJumpBoots);
			// || CanIBJ(have)
		} 						
 private static bool CanAccessIceBeamPath(List<ItemType> have)
        {

			return have.Contains(ItemType.MorphingBall)
			&& have.Contains(ItemType.SuperMissile)
			&& have.Contains(ItemType.VariaSuit);
			//adjust for hellruns in harder difficulties
				
		} 						
 private static bool CanAccessNorfair(List<ItemType> have)
        {

			return have.Contains(ItemType.VariaSuit)
			// && have.Contains(ItemType.MorphingBall)
				&& CanOpenMissileDoors(have);
		} 								
 private static bool CanEnterRightNorfair(List<ItemType> have)
        {

			return CanAccessNorfair(have)
			&& CanOpenMissileDoors(have)
			
			&& (have.Contains(ItemType.HiJumpBoots)
			// CanIBJ(have)
			&& (have.Contains(ItemType.GrappleBeam))

			|| have.Contains(ItemType.SpaceJump));
			//Can get to the same spot with just varia suit
			//useless code
		} 						
 private static bool CanAccessMiddleNorfair(List<ItemType> have)
        {

			return CanAccessNorfair(have)
			&& (have.Contains(ItemType.IceBeam)
			|| have.Contains(ItemType.HiJumpBoots)
			|| have.Contains(ItemType.SpaceJump));
		} 							
 private static bool CanAccessMaridiaTube(List<ItemType> have)
        {

			return have.Contains(ItemType.VariaSuit)
			&& have.Contains(ItemType.GravitySuit)
			&& have.Contains(ItemType.SuperMissile)
			&& have.Contains(ItemType.HiJumpBoots)
			// hj for casual players, otherwise ibj
				&& CanUsePowerBombs(have);
			// check again
			//unused code
		} 									
 private static bool CanAccessLN(List<ItemType> have)
        {

			return CanAccessMiddleNorfair(have)
				//casual charge beam limit
				&& have.Contains(ItemType.MorphingBall)
			// && CanAccessMaridiaTube
			// not sure if add maridia items
				&& have.Contains(ItemType.SpringBall)
				&& BossArea(have);
			//SpringBall for casual
		} 									
 private static bool CanEnterMaridia(List<ItemType> have)
        {

			return CanOpenMissileDoors(have)
			&& have.Contains(ItemType.SpringBall)
			// or mockball
				&& CanEnterPassages(have)
				&& have.Contains(ItemType.GravitySuit);
			// turn on gravity for casual
		} 									
 private static bool BackdoorMaridia(List<ItemType> have)
        {

 	return CanUsePowerBombs(have)
 		&& have.Contains(ItemType.GravitySuit);
		} 										
 private static bool CanEnterThirteenthStreet(List<ItemType> have)
        {

			return CanEnterMaridia(have)
			// && have.Contains(ItemType.SpringBall)
			&& have.Contains(ItemType.Missile)
			&& have.Contains(ItemType.HiJumpBoots)
			// might have to rethink the logic
				&& BossArea(have);
		} 										
 private static bool MaridiaRuins(List<ItemType> have)
        {
			//Maridia Route
			return (CanEnterMaridia(have)
			&& CanUsePowerBombs(have)
			&& (have.Contains(ItemType.HiJumpBoots)))
			// && have.Contains(ItemType.GravitySuit)))
			//can have || gravity for harder difficulties
			
			//WS Route
			|| (CanEnterInnerWS(have)
				    && CanEnterPassages(have));
		} 										
 private static bool CanEnterMaridiaDepths(List<ItemType> have)
        {
			//WS Route
			return CanEnterInnerWS(have)
			
			//Maridia Ruins Route
			
			|| (CanEnterMaridia(have)
			&& CanUsePowerBombs(have)
			&& (have.Contains(ItemType.HiJumpBoots)));
			    //&& have.Contains(ItemType.GravitySuit)));
			//can have || gravity for harder difficulties
			
		}  
 private static bool CanFightCrocomire(List<ItemType> have)
        {
			return CanAccessNorfair(have)
           	&& have.Contains(ItemType.MorphingBall)
				&& have.Contains(ItemType.SuperMissile);
			
		} 
private static bool BossArea(List<ItemType> have)
        {
	//balance for casuals in deeper areas like LN. Use this to push items to easier areas of the game.
	return have.Contains(ItemType.ChargeBeam)
		&& have.Contains(ItemType.PlasmaBeam)
			&& have.Count(x => x == ItemType.EnergyTank) >= 4;
			
		}   

 
 
									
		
        private static int EnergyReserveCount(List<ItemType> have)
        {
            var energyTankCount = have.Count(x => x == ItemType.EnergyTank);
            var reserveTankCount = Math.Min(have.Count(x => x == ItemType.ReserveTank), energyTankCount + 1);
            return energyTankCount + reserveTankCount;
        }
        public RomLocationsMasochist()
        {
            ResetLocations();
        }

        public List<Location> GetAvailableLocations(List<ItemType> haveItems)
        {
            var retVal = (from Location location in Locations where (location.Item == null) && location.CanAccess(haveItems) select location).ToList();
            var currentWeight = (from item in retVal orderby item.Weight descending select item.Weight).First() + 1;

            foreach (var item in retVal.Where(item => item.Weight == 0))
            {
                item.Weight = currentWeight;
            }

            var addedItems = new List<List<Location>>();
            for (int i = 1; i < currentWeight; i++)
            {
                addedItems.Add(retVal.Where(x => x.Weight > i).ToList());
            }

            foreach (var list in addedItems)
            {
                retVal.AddRange(list);
            }

            return retVal;
        }

        public List<Location> GetUnavailableLocations(List<ItemType> haveItems)
        {
            return (from Location location in Locations where location.Item == null && !location.CanAccess(haveItems) select location).ToList();
        }

        public void TryInsertCandidateItem(List<Location> currentLocations, List<ItemType> candidateItemList, ItemType candidateItem)
        {
			// only try gravity if gravity is okay in this spot
			// only insert multiples of an item into the candidate list if we aren't looking at the morph ball slot.
			if (currentLocations.All(x => x.Name != "Morphing Ball") || !candidateItemList.Contains(candidateItem))
            {
                candidateItemList.Add(candidateItem);
            }
        }

        public int GetInsertedLocation(List<Location> currentLocations, ItemType insertedItem, SeedRandom random)
        {
            return random.Next(currentLocations.Count);
        }

        public ItemType GetInsertedItem(List<Location> currentLocations, List<ItemType> itemPool, SeedRandom random)
        {
            return itemPool[random.Next(itemPool.Count)];
        }

        public List<ItemType> GetItemPool(SeedRandom random)
        {
            return new List<ItemType>
                       {
                           ItemType.MorphingBall,
                           ItemType.Bomb,
                           ItemType.SpringBall,
                           ItemType.ScrewAttack,
                           ItemType.HiJumpBoots,
                           ItemType.SpaceJump,
                           ItemType.SpeedBooster,
                           
                           ItemType.VariaSuit,
                           ItemType.GravitySuit,
                           
                           ItemType.ChargeBeam,
                           ItemType.IceBeam,
                           ItemType.WaveBeam,
                           ItemType.Spazer,
                           ItemType.PlasmaBeam,
                           
                           
                           ItemType.GrappleBeam,
                           ItemType.XRayScope,
                           
                           // 5 reserve tanks
                           ItemType.ReserveTank,
                           ItemType.ReserveTank,
                           ItemType.ReserveTank,
                           ItemType.ReserveTank,
                           ItemType.ReserveTank,
						   // 41 Missiles
						   ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							ItemType.Missile,
							
						 	  // 13 Supers
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							ItemType.SuperMissile,
							
							
						   // 11 Power Bombs
							ItemType.PowerBomb,
							ItemType.PowerBomb,
							ItemType.PowerBomb,
							ItemType.PowerBomb,
							ItemType.PowerBomb,
							ItemType.PowerBomb,
							ItemType.PowerBomb,
							ItemType.PowerBomb,
							ItemType.PowerBomb,
							ItemType.PowerBomb,
							ItemType.PowerBomb,

                           //14 E-tanks
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           
                           //100%
                       };
        }
    }
}
