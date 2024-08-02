import AWS from 'aws-sdk';
import middy from '@middy/core';
import jsonBodyParser from '@middy/http-json-body-parser';
import httpErrorHandler from '@middy/http-error-handler';
import cors from '@middy/http-cors';
// import JWTAuthMiddleware, {
//     EncryptionAlgorithms,
//   } from "middy-middleware-jwt-auth";
  
const dynamoDb = new AWS.DynamoDB.DocumentClient();

export const getFriends = async (event) => {
    const userId = event?.auth?.payload?.sub ?? "test";

    const params = {
        TableName: 'FriendsTable',
        FilterExpression: 'contains(#key, :userId)',
        ExpressionAttributeNames: {
            '#key': 'userIds'
        },
        ExpressionAttributeValues: {
            ':userId': userId
        }
    };

    try {
        const data = await dynamoDb.scan(params).promise();
        return {
            statusCode: 200,
            body: JSON.stringify(data.Items)
        };
    } catch (error) {
        return {
            statusCode: 500,
            body: JSON.stringify({ error: 'Could not fetch friends' })
        };
    }
};

export const sendFriendRequest = async (event) => {
    const currentUserId = event.auth.payload.sub;
    const { requestedFriendId } = event.body;

    const userIds = [currentUserId, requestedFriendId].sort().join('*');

    const params = {
        TableName: 'FriendsTable',
        Item: {
            userIds: userIds,
            status: 'pending'
        }
    };

    try {
        await dynamoDb.put(params).promise();
        return {
            statusCode: 200,
            body: JSON.stringify({ message: 'Friend request sent' })
        };
    } catch (error) {
        return {
            statusCode: 500,
            body: JSON.stringify({ error: 'Could not send friend request' })
        };
    }
};


const enableMiddleware = (func) => middy(func)
    .use(jsonBodyParser())
    // .use(
    //     JWTAuthMiddleware({
    //       /** Algorithm to verify JSON web token signature */
    //       algorithm: EncryptionAlgorithms.HS256,
    //       /** An optional boolean that enables making authorization mandatory */
    //       credentialsRequired: true,
    //       /** An optional function that checks whether the token payload is formatted correctly */
    //     //   isPayload: isTokenPayload,
    //       /** A string or buffer containing either the secret for HMAC algorithms, or the PEM encoded public key for RSA and ECDSA */
    //       secretOrPublicKey: process.env.AUTH0_SECRET,
    //       /**
    //        * An optional function used to search for a token e. g. in a query string. By default, and as a fall back,
    //        * event.headers.authorization and event.headers.Authorization are used.
    //        */
    //       tokenSource: (event) => event.queryStringParameters.token,
    //     })
    // )
    .use(httpErrorHandler())
    .use(cors());

// Export an object with all handlers
export default {
    getFriends: enableMiddleware(getFriends),
    sendFriendRequest: enableMiddleware(sendFriendRequest),
};
