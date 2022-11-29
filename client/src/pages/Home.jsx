import React from "react";

import RenatApaev from "../components/RenatApaev";
import Socials from "../components/Socials";
import About from "../components/About";
import Stack from "../components/Stack";

const Home = () => {
    return (
        <section className='min-h-screen'>
            <RenatApaev></RenatApaev>
            <Socials></Socials>
            <About></About>
            <Stack></Stack>
        </section>
    )
};

export default Home;