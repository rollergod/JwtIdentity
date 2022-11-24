import './App.css';

import { BsFillMoonStarsFill, BsTelegram } from 'react-icons/bs';
import { AiFillGithub } from 'react-icons/ai';

import {
  SiVk, SiDotnet, SiVisualstudio, SiVisualstudiocode, SiReact, SiRedux,
  SiDocker, SiTypescript, SiMicrosoftsqlserver, SiMongodb, SiCsharp, SiJavascript, SiSwagger, SiFigma
} from 'react-icons/si';


function App() {
  return (
    <div className="App">

      <main className='bg-white px-10'>
        <section className='min-h-screen'>
          <nav className='py-10 mb-12 flex justify-between'>
            <h1 className='text-xl'>developedbyrollergod</h1>
            <ul className='flex items-center'>
              <li> <BsFillMoonStarsFill className='cursor-pointer text-2xl' /> </li>
              <li>
                <a className='bg-gradient-to-r from-cyan-500 to-teal-500 text-white px-4 py-2 rounded-md ml-8' href="#">About</a>
              </li>
              <li>
                <a className='bg-gradient-to-b from-purple-500 to-purple-700 text-white px-4 py-2 rounded-md ml-8' href="#">Resume</a>
              </li>
              <li>
                <a className='bg-gradient-to-t from-orange-500 to-orange-600 text-white px-4 py-2 rounded-md ml-8' href="#">Github</a>
              </li>
            </ul>
          </nav>
          <div className='text-center w-1/2 mx-auto py-10'>
            <h2 className='text-5xl py-2 text-teal-600 font-medium'>Renat Apaev</h2>
            <h3 className='text-2xl py-2'>Backend developer</h3>
          </div>
          <div className='text-5xl flex justify-center gap-16 py-3 text-gray-600 mb-16'>
            <AiFillGithub />
            <BsTelegram />
            <SiVk />
          </div>
          <div className='mb-16'>
            <h3 className='text-3xl py-1 font-medium'>About me</h3>
            <p className='mx-auto text-md py-2 leading-8 text-gray-800 w-1/2'>
              My name is Renat. I`m from Russia and i`m 20 years old and i like to <span className='text-teal-500'>write code</span>.
              <br />
              Since the beginning of my journey, I have discovered a lot of <span className='text-blue-700'>new things</span>.
              I get a lot of pleasure when I write code.
              <br />
              Every day I try to reach <span className='text-teal-500'>new heights.</span>
            </p>
          </div>

          <div>
            <h3 className='text-3xl py-5 font-medium'>My developer stack</h3>

            <div class="w-2/3 mx-auto grid overflow-hidden grid-cols-5 grid-rows-2 gap-px">
              <div class="box">
                <div className='text-3xl'>
                  <h4>IDEs</h4>
                  <div className='text-3xl flex justify-around py-2 '>
                    <SiVisualstudio className='text-purple-600' />
                    <SiVisualstudiocode className='text-cyan-400' />
                  </div>
                </div>
              </div>

              <div class="box col-start-3 col-end-4">
                <div className='text-3xl'>
                  <h4>frontend</h4>
                  <div className='text-4xl flex justify-between py-2 '>
                    <SiJavascript className='text-yellow-400' />
                    <SiTypescript className='text-blue-500' />
                    <SiReact className='text-cyan-300' />
                    <SiRedux className='text-violet-500' />
                  </div>
                </div>
              </div>

              <div class="box col-start-5 col-end-6">
                <div className='text-3xl'>
                  <h4>backend</h4>
                  <div className='text-4xl flex justify-around py-2'>
                    <SiCsharp className='text-green-500' />
                    <SiDotnet className='text-indigo-700' />
                    <SiSwagger className='text-lime-500' />
                  </div>
                </div>
              </div>

              <div class="box col-start-2 col-end-3">
                <div className='text-3xl'>
                  <h4>databases</h4>
                  <div className='text-4xl flex justify-evenly '>
                    <SiMicrosoftsqlserver className='text-red-600' />
                    <SiMongodb className='text-green-600' />
                  </div>
                </div>
              </div>

              <div class="box col-start-4">
                <div className='text-3xl'>
                  <h4>useful staff</h4>
                  <div className='text-4xl flex justify-evenly py-1'>
                    <SiDocker className='text-blue-500' />
                    <SiFigma />
                  </div>
                </div>
              </div>

            </div>

          </div>

        </section>
      </main>
    </div>
  );
}

export default App;
