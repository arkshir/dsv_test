/**
 * Movies API
 *
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { HttpHeaders }                                       from '@angular/common/http';

import { Observable }                                        from 'rxjs';

import { FastEndpointsProblemDetails } from '../model/models';
import { MoviesApiApiEndpointsMoviesGetGetMovieResponse } from '../model/models';
import { MoviesApiApiEndpointsMoviesListListMoviesResponse } from '../model/models';


import { Configuration }                                     from '../configuration';



export interface MoviesServiceInterface {
    defaultHeaders: HttpHeaders;
    configuration: Configuration;

    /**
     * 
     * 
     * @param id 
     */
    moviesApiApiEndpointsMoviesGetGetMovieEndpoint(id: number, extraHttpRequestParams?: any): Observable<MoviesApiApiEndpointsMoviesGetGetMovieResponse>;

    /**
     * 
     * 
     * @param page 
     * @param pageSize 
     * @param orderBy 
     * @param filter 
     */
    moviesApiApiEndpointsMoviesListListMoviesEndpoint(page: number, pageSize: number, orderBy: string, filter?: string, extraHttpRequestParams?: any): Observable<MoviesApiApiEndpointsMoviesListListMoviesResponse>;

}
