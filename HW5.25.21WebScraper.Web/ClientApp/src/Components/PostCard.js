import React, { useState, useEffect } from 'react';

const PostCard = ({post}) => {
    const {imageUrl, title, blurb, numberOfComments, url} = post;
    return (<>
        <div className="card mt-2 border-dark">
            <div className="card-body">
                <a href={url} target="_blank">
                <h5 className="card-title">{title}</h5>
                </a>
                <a href={url} target="_blank">
                <img className="img img-fluid max-width: 100%" src={imageUrl}></img>
                </a>
                <p className="card-text">{blurb} <a href={url} target="_blank">Read more...</a></p> 
                <small className="text-muted">{numberOfComments}</small>
            </div>
        </div>
    </>
    );
}

export default PostCard;