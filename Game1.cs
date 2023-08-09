using GameProject.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static int ScreenHeight;
        public static int ScreenWidth;
        private Camera _camera;
        private List<Sprite> _components;
        
        private List<Biome> _biomes;
        Biome grassland;
        Biome desert;
        Biome birchforest;
        Biome countryland; 
        Biome magicalforest;
        Biome mapleforest;
        Biome CherryWoods;
        Biome Moun;
        Biome cold;
        Biome flower;
        Biome DeathD;
        Biome CB;

        Biome Taiga;
        Biome Swamp;
        Biome Al;
        Biome Com;


        private Player _player;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            grassland = new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/gl"), new Vector2(-1000, 550));
            desert = new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/desertbiome"), new Vector2(500, 1000));

            birchforest= new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/birchforest"), new Vector2(-1200, -1200));
            countryland= new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/countryland"), new Vector2(-400, 300));
            magicalforest= new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/magicalforest"), new Vector2(1000, 200));
            mapleforest= new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/mapleforest"), new Vector2(-300, -1150));
            CherryWoods= new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/cherrywoods"), new Vector2(1200, -1150));
            Moun= new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/mountains"), new Vector2(-400, -300));
            cold= new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/coldbiome"), new Vector2(600, -1150));
            flower= new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/flower"), new Vector2(500, 350));
            DeathD= new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/deathdesertbiome"), new Vector2(-1300, -300));
            CB= new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/ci"), new Vector2(-2000, 2500));
            Swamp = new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/swampbiome"), new Vector2(-1000, 1250));
            Taiga = new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/taigabiome"), new Vector2(-500, 1200));
            Al = new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/alaphanty"), new Vector2(2000, 2400));
            Com = new Biome(Content.Load<Texture2D>("./Sprites/Art/Others/Biomes/comory"), new Vector2(-2000, -2000));
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _camera = new Camera();
            _player = new Player(Content.Load<Texture2D>("./Sprites/path234"), false);
            _components = new List<Sprite>()
            {
                _player,
                new Sprite(Content.Load<Texture2D>("./Sprites/rect234"), false)
            };
            _biomes = new List<Biome>()
            {
                
                mapleforest,
                grassland,
                desert,
                birchforest,
                countryland,
                cold,
                flower,
                Moun,
                countryland,
                DeathD,
                Swamp,
                Taiga,
                Al,
                Com,
                CherryWoods,
                magicalforest
        };
            
                

           
          
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            foreach (var component in _components)
            {
                component.Update(gameTime, _components);
                _camera.Follow(_player);
            }
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(transformMatrix: _camera.Transform);
            // TODO: Add your drawing code here
            foreach (var biome in _biomes)
            {
                biome.Draw(gameTime, _spriteBatch);
            }
            foreach (var component in _components)
            {
                component.Draw(gameTime, _spriteBatch);
               
            }
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}