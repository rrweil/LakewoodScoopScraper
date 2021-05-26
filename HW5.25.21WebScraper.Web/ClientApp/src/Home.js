import React, { useState, useEffect } from 'react';  
import axios from 'axios';  
import PostCard from './Components/PostCard';

const Home = () => {
    const [results, setResults] = useState([]);
    

    useEffect(() => {
        scrapeLakewoodScoop();
    }, []);

    const scrapeLakewoodScoop = async () => {
        const { data } = await axios.get(`/api/scraper/scrape`);
        setResults(data);
    }
      return ( 

        <div className="container" style={{ marginTop: 60 }}>
        <div className="row">
            <div className="col-md-6 offset-4">
                 {results.map(post => { return <PostCard post={post}/>})}
            </div>
        </div>
    </div>
      
    );
    
}
 
export default Home;