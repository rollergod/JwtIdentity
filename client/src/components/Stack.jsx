import React from "react";

import {
    SiDotnet, SiVisualstudio, SiVisualstudiocode, SiReact, SiRedux,
    SiDocker, SiTypescript, SiMicrosoftsqlserver, SiMongodb, SiCsharp, SiJavascript, SiSwagger, SiFigma
} from 'react-icons/si';

const Stack = () => {
    return (
        <div>
            <h3 className='text-3xl py-5 font-medium'>My developer stack</h3>

            <div class="w-2/3 mx-auto grid overflow-hidden grid-cols-5 grid-rows-2 gap-px">
                <div class="box">
                    <div className='text-3xl'>
                        <h4>IDEs</h4>
                        <div className='text-3xl flex justify-around py-2 '>
                            <a href="https://visualstudio.microsoft.com/ru/" target="_blank">
                                <SiVisualstudio className='text-purple-600 hover:text-purple-500 transition duration-300' />
                            </a>
                            <a href="https://code.visualstudio.com/" target="_blank">
                                <SiVisualstudiocode className='text-cyan-400 hover:text-cyan-500 transition duration-300' />
                            </a>
                        </div>
                    </div>
                </div>

                <div class="box col-start-3 col-end-4">
                    <div className='text-3xl'>
                        <h4>frontend</h4>
                        <div className='text-4xl flex justify-between py-2 '>
                            <a href="https://developer.mozilla.org/en-US/docs/Web/JavaScript" target="_blank">
                                <SiJavascript className='text-yellow-400 hover:text-yellow-500 transition duration-300' />
                            </a>
                            <a href="https://www.typescriptlang.org/" target="_blank">
                                <SiTypescript className='text-blue-500 hover:text-blue-600 transition duration-300' />
                            </a>
                            <a href="https://en.reactjs.org/" target="_blank">
                                <SiReact className='text-cyan-300 hover:text-cyan-400 transition duration-300' />
                            </a>
                            <a href="https://redux.js.org/" target="_blank">
                                <SiRedux className='text-violet-500 hover:text-violet-600 transition duration-300' />
                            </a>
                        </div>
                    </div>
                </div>

                <div class="box col-start-5 col-end-6">
                    <div className='text-3xl'>
                        <h4>backend</h4>
                        <div className='text-4xl flex justify-around py-2'>
                            <a href="https://learn.microsoft.com/en-us/dotnet/csharp/" target="_blank">
                                <SiCsharp className='text-green-500 hover:text-green-600 transition duration-300' />
                            </a>
                            <a href="https://dotnet.microsoft.com/en-us/" target="_blank">
                                <SiDotnet className='text-indigo-700 hover:text-indigo-800 transition duration-300' />
                            </a>
                            <a href="https://swagger.io/" target="_blank">
                                <SiSwagger className='text-lime-500 hover:text-lime-600 transition duration-300' />
                            </a>
                        </div>
                    </div>
                </div>

                <div class="box col-start-2 col-end-3">
                    <div className='text-3xl'>
                        <h4>databases</h4>
                        <div className='text-4xl flex justify-evenly '>
                            <a href="https://www.microsoft.com/en-us/sql-server/sql-server-2019" target="_blank">
                                <SiMicrosoftsqlserver className='text-red-600 hover:text-red-700 transition duration-300' />
                            </a>
                            <a href="https://www.mongodb.com/home" target="_blank">
                                <SiMongodb className='text-green-600 hover:text-green-700 transition duration-300' />
                            </a>
                        </div>
                    </div>
                </div>

                <div class="box col-start-4">
                    <div className='text-3xl'>
                        <h4>useful staff</h4>
                        <div className='text-4xl flex justify-evenly py-1'>
                            <a href="https://www.docker.com/" target="_blank">
                                <SiDocker className='text-blue-500 hover:text-blue-600 transition duration-300' />
                            </a>
                            <a href="https://www.figma.com/" target="_blank">
                                <SiFigma className="hover:text-sky-700 transition duration-300" />
                            </a>
                        </div>
                    </div>
                </div>

            </div >

        </div >
    )
};

export default Stack;