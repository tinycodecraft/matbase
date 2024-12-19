
import { ApiStatusEnum, ErrorEnum } from './enums'
import {
  FetchNextPageOptions,
  InfiniteData,
  InfiniteQueryObserverResult,
  QueryObserverResult,
  RefetchOptions,
  RefetchQueryFilters,
} from '@tanstack/react-query'
import { SetStateAction } from 'react'
import { UserData } from './apis'


export type UploadedFileState = {
  filePath?: string
  fileDesc?: string
}

export type UploadState = {
  connectionId: string
  status: ApiStatusEnum
  progress?: number
  fileResults?: UploadedFileState[]
}


export type FileUploadSummaryState = {
  totalFilesUploaded: number
  totalSizeUploaded: string
  filePaths: string[]
  fileDescs: string[]
}



export type ListResult<T> = Readonly<{
  start: number
  total_count: number
  data: T[]
}>

export type ExportResult = Readonly<{
  link: string
  type: string
}>

export type LabelDetail = Readonly<{
  value: string
  label: string
}>

export type ErrorDetail = Readonly<{
  code: string
  description: string
  type: ErrorEnum | number
  numericType: number
}>

export type ErrorOr<T> = Readonly<{
  status?: ApiStatusEnum
  isError: boolean
  errors: ErrorDetail[]
  value?: T
}>

export type UnsubscribeFunc = () => void
export type receiveHandlerType<T> = (data: ErrorOr<T>) => void
export type resultHandlerType = (result: ErrorOr<string>) => boolean

export type QueryForm<T> = Readonly<{
  id: string
  handler: receiveHandlerType<T>
}>


export type SaveForm<T> = Readonly<{
  data: T
  handler: resultHandlerType
}>


