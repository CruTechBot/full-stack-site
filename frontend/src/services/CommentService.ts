import {get, securePost, securePut} from './AxiosService'

const base = "/Comments";

export function addComment(comment: string) {
    return securePost(base + '/Add', {content: comment})
}

export function getAllComments() {
    return get(base + '/All')
}

export function deleteComment(id: number)
{
    return securePut(base + '/Delete',{content: id})
}